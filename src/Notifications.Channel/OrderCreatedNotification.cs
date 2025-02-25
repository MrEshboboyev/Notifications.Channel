using MediatR;
using Notifications.Channel;
using System.Diagnostics;

public class OrderCreatedNotification : INotification
{
    public Guid OrderId { get; init; }
    public string? ParentId { get; init; }
}

public class OrderCreatedHandler(ILogger<OrderCreatedHandler> logger)
    : INotificationHandler<OrderCreatedNotification>
{
    public Task Handle(
        OrderCreatedNotification notification, 
        CancellationToken token)
    {
        using var activity = DiagnosticConfig.Source.StartActivity(
            "OrderCreatedHandler.Handle",
            ActivityKind.Internal,
            notification.ParentId);

        logger.LogInformation(
            "Normal handler completed for Order {OrderId}", 
            notification.OrderId);

        return Task.CompletedTask;
    }
}

public class SlowOrderCreatedHandler(ILogger<SlowOrderCreatedHandler> logger)
    : INotificationHandler<OrderCreatedNotification>
{
    public async Task Handle(
        OrderCreatedNotification notification,
        CancellationToken token)
    {
        using var activity = DiagnosticConfig.Source.StartActivity(
            "SlowOrderCreatedHandler.Handle",
            ActivityKind.Internal,
            notification.ParentId);

        await Task.Delay(500, token); // simulate work

        logger.LogInformation(
            "Slow handler completed for Order {OrderId}",
            notification.OrderId);
    }
}

public class VerySlowOrderCreatedHandler(ILogger<VerySlowOrderCreatedHandler> logger)
    : INotificationHandler<OrderCreatedNotification>
{
    public async Task Handle(
        OrderCreatedNotification notification,
        CancellationToken token)
    {
        using var activity = DiagnosticConfig.Source.StartActivity(
            "VerySlowOrderCreatedHandler.Handle",
            ActivityKind.Internal,
            notification.ParentId);

        await Task.Delay(2000, token); // simulate work

        logger.LogInformation(
            "Very Slow handler completed for Order {OrderId}",
            notification.OrderId);
    }
}