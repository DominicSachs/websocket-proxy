using EasyNetQ;
using Messages;

namespace WorkerService2;

public class Worker : BackgroundService
{
    private readonly IBus _bus;
    private readonly ILogger<Worker> _logger;

    public Worker(IBus bus, ILogger<Worker> logger)
    {
        _bus = bus;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var i = 1;

        while (true)
        {
            var information = $"Notification {i++} from service 2 at {DateTimeOffset.Now}";
            _logger.LogInformation(information);

            await _bus.PubSub.PublishAsync(new InformationEvent(information));
            await Task.Delay(1000, stoppingToken);
        }
    }
}