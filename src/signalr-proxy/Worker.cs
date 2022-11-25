using EasyNetQ;
using Messages;

namespace SignalrProxy;

public class Worker : BackgroundService
{
    private const string SUBSCRIPTION_ID = "SignalrProxy";
    private readonly IBus _bus;
    private readonly MessageConsumer _messageConsumer;

    public Worker(IBus bus, MessageConsumer messageConsumer)
    {
        _bus = bus;
        _messageConsumer = messageConsumer;
    }


    protected override async Task ExecuteAsync(CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        await _bus.PubSub.SubscribeAsync<InformationEvent>(SUBSCRIPTION_ID, async e => await _messageConsumer.HandleInformationEventAsync(e.Information, token), token);
    }
}