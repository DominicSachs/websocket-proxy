using Api.Hubs.Abstractions;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs;

public sealed class MyHub : Hub<IMyHub>
{
    private readonly ILogger<MyHub> _logger;

    public MyHub(ILogger<MyHub> logger)
    {
        _logger = logger;

    }

    public async Task InformationReceived(string message)
    {
        _logger.LogInformation("MyHub.InformationReceived: {message}", message);

        await Clients.Others.SendInformation(message);
    }
}
