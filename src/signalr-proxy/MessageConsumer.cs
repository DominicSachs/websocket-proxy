namespace SignalrProxy;

public sealed class MessageConsumer
{
    private readonly IHubProxy _hubProxy;

    public MessageConsumer(IHubProxy hubProxy)
    {
        _hubProxy = hubProxy;
    }

    public async Task HandleInformationEventAsync(string information, CancellationToken token)
    {
        await _hubProxy.SendAsync("InformationReceived", information, token);
    }
}
