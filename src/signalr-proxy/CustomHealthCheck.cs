using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SignalrProxy;

public sealed class CustomHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new HealthCheckResult(HealthStatus.Healthy));
    }
}
