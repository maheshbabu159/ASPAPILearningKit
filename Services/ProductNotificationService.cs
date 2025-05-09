using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

public class ProductNotificationService : BackgroundService
{
    private readonly IHubContext<ProductHub> _hubContext;
    private readonly ILogger<ProductNotificationService> _logger;

    public ProductNotificationService(IHubContext<ProductHub> hubContext, ILogger<ProductNotificationService> logger)
    {
        _hubContext = hubContext;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = $"Heartbeat at {DateTime.Now:HH:mm:ss}";
            _logger.LogInformation("Sending message: {Message}", message);

            await _hubContext.Clients.All.SendAsync("ReceiveProduct", message, cancellationToken: stoppingToken);

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // 5-minute interval
        }
    }
}