using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalrProxy;

public sealed class HubProxy : IHubProxy
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<HubProxy> _logger;
    private HubConnection? _hubConnection;
    private readonly string _hubUrl;

    public HubProxy(IConfiguration configuration, ILogger<HubProxy> logger)
    {
        _configuration = configuration;
        _logger = logger;
        _hubUrl = _configuration.GetValue<string>("AppSettings:HubUrl")!;
    }

    public async Task SendAsync(string methodName, object? argument, CancellationToken token = default)
    {
        _logger.LogInformation("Send to {method} with {argument}", methodName, argument);

        await CreateConnection(token);
        await _hubConnection!.InvokeAsync(methodName, argument, cancellationToken: token);
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
            .WithUrl(_hubUrl!, a =>
            {
                a.WebSocketConfiguration = conf =>
                {
                    conf.RemoteCertificateValidationCallback = (message, cert, chain, errors) => { return true; };
                };

                a.SkipNegotiation = true;
                a.Transports = HttpTransportType.WebSockets;
            })
            .WithAutomaticReconnect()
            .ConfigureLogging(l =>
            {
                l.SetMinimumLevel(LogLevel.Debug);
                l.AddConsole();
            })
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