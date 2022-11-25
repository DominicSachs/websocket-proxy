namespace SignalrProxy;

public sealed class MessageConsumer
{
    private readonly IHubProxy _hubProxy;
    private readonly ILogger<MessageConsumer> _logger;

    public MessageConsumer(IHubProxy hubProxy, ILogger<MessageConsumer> logger)
    {
        _hubProxy = hubProxy;
        _logger = logger;
    }

    public async Task HandleInformationEventAsync(string information, CancellationToken token)
    {
        _logger.LogInformation($"Sending InformationReceived with: {information}");

        await _hubProxy.SendAsync("InformationReceived", information, token);

    }
}
