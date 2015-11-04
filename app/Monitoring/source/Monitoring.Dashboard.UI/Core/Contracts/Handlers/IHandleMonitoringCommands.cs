using System.Collections.Generic;
using Monitoring.Dashboard.UI.Infrastructure.Dto;
using Monitoring.Dashboard.UI.Infrastructure.Commands;

namespace Monitoring.Dashboard.UI.Core.Contracts.Handlers
{
    public interface IHandleMonitoringCommands
    {
        List<DataProviderDto> MonitoringResponse { get; }
        void Handle(GetMonitoringCommand command);
    }
}
