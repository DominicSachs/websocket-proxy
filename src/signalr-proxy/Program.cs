using EasyNetQ;

namespace SignalrProxy;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetValue<string>("AppSettings:RabbitConnection");

                services.AddSingleton(RabbitHutch.CreateBus(connectionString));
                services.AddSingleton<IHubProxy, HubProxy>();
                services.AddSingleton<MessageConsumer>();
                services.AddHostedService<Worker>();
            })
            .Build();

        host.Run();
    }
}