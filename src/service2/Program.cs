using EasyNetQ;

namespace WorkerService2;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetValue<string>("AppSettings:RabbitConnection");

                services.AddSingleton(RabbitHutch.CreateBus(connectionString));
                services.AddHostedService<Worker>();
            })
            .Build();

        host.Run();
    }
}