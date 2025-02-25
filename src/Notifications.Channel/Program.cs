using MediatR;
using MediatR.NotificationPublishers;
using Notifications.Channel;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Configure MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<Program>();

    cfg.NotificationPublisherType = typeof(ChannelPublisher);
});

// configure OpenTelemetry
builder.Services
    .AddOpenTelemetry()
    .ConfigureResource(r => r.AddService(DiagnosticConfig.Source.Name))
    .WithTracing(tracing =>
        tracing
            .AddAspNetCoreInstrumentation()
            .AddSource(DiagnosticConfig.Source.Name))
    .UseOtlpExporter();

builder.Services.AddScoped<NotificationsQueue>();   
builder.Services.AddHostedService<ChannelNotificationProcessor>();

var app = builder.Build();

// endpoints
app.MapPost("orders", async (IPublisher publisher) =>
{
    using var activity = DiagnosticConfig.Source.StartActivity("CreateOrder");

    var orderId = Guid.NewGuid();

    await publisher.Publish(new OrderCreatedNotification 
    { 
        OrderId = orderId, 
        ParentId = activity?.Id 
    });

    return Results.Ok(orderId);
});

app.Run();
