using System.Diagnostics;

namespace Notifications.Channel;

internal static class DiagnosticConfig
{
    internal static readonly ActivitySource Source = new("Order.Service");
}
