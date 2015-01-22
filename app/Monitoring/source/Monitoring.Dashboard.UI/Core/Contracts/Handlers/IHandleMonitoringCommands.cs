using System.Collections.Generic;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Infrastructure.Commands;

namespace Monitoring.Dashboard.UI.Core.Contracts.Handlers
{
    public interface IHandleMonitoringCommands
    {
        IEnumerable<MonitoringResponse> MonitoringResponse { get; }
        MonitoringResponse MonitoringResponseItem { get; }
        void Handle(GetMonitoringCommand command);
        void Handle(GetMonitoringItemCommand command);
    }
}
