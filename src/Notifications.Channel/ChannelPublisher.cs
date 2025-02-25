using MediatR;
using System.Threading.Channels;

namespace Notifications.Channel;

public record NotificationEntry(
    NotificationHandlerExecutor[] Handlers, 
    INotification Notification);
public sealed class NotificationsQueue(int capacity = 100)
{
    private readonly Channel<NotificationEntry> _queue = 
        System.Threading.Channels.Channel.CreateBounded<NotificationEntry>(
            new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            });

    public ChannelReader<NotificationEntry> Reader => _queue.Reader;
    public ChannelWriter<NotificationEntry> Writer => _queue.Writer;
}
public class ChannelPublisher(NotificationsQueue queue) : INotificationPublisher
{
    public async Task Publish(
        IEnumerable<NotificationHandlerExecutor> handlerExecutors, 
        INotification notification, 
        CancellationToken cancellationToken)
    {
        await queue.Writer.WriteAsync(
            new NotificationEntry(
                [.. handlerExecutors], 
                notification), 
            cancellationToken);
    }
}

public class ChannelNotificationProcessor(NotificationsQueue queue) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var entry in queue.Reader.ReadAllAsync(stoppingToken))
        {
            await Parallel.ForEachAsync(entry.Handlers, stoppingToken, async (executor, token) =>
            {
                await executor.HandlerCallback(entry.Notification, token);
            });
        }
    }
}
