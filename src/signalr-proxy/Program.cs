using EasyNetQ;

namespace SignalrProxy;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddSingleton(RabbitHutch.CreateBus("host=localhost"));
                services.AddSingleton<IHubProxy, HubProxy>();
                services.AddSingleton<MessageConsumer>();
                services.AddHostedService<Worker>();
            })
            .Build();

        host.Run();
    }
}