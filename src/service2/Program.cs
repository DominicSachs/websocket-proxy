using EasyNetQ;

namespace WorkerService2;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddSingleton(RabbitHutch.CreateBus("host=localhost"));
                services.AddHostedService<Worker>();
            })
            .Build();

        host.Run();
    }
}