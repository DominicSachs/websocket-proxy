namespace SignalrProxy;

public interface IHubProxy
{
    Task SendAsync(string methodName, object? arg1, CancellationToken cancellationToken = default);
}