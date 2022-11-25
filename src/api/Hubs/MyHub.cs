using Api.Hubs.Abstractions;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs;

public class MyHub : Hub<IMyHub>
{
    public async Task InformationReceived(string message)
    {
        await Clients.All.SendInformation(message);
    }
}
