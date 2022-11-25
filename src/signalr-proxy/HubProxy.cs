using Microsoft.AspNetCore.SignalR.Client;

namespace SignalrProxy;

public sealed class HubProxy : IHubProxy
{
    private HubConnection? _hubConnection;


    public async Task SendAsync(string methodName, object? argument, CancellationToken token = default)
    {
        await CreateConnection(token);
        await _hubConnection!.SendAsync(methodName, argument, token);
    }

    private async Task CreateConnection(CancellationToken token)
    {
        if (_hubConnection == null)
        {
            InitializeConnection();
        }

        await SafeStartAsync(_hubConnection!, token);
    }

    private void InitializeConnection()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7169/my-hub")
            .WithAutomaticReconnect()
            .ConfigureLogging(l => l.AddConsole())
            .Build();
    }

    private Task SafeStartAsync(HubConnection connection, CancellationToken token)
    {
        if (connection.State == HubConnectionState.Disconnected)
        {
            return connection.StartAsync(token);
        }

        return Task.CompletedTask;
    }
}