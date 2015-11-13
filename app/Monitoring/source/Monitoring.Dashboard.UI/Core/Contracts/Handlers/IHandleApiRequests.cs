using System.Collections.Generic;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Core.Contracts.Handlers
{
    public interface IHandleApiRequests
    {
        List<ApiRequestMonitoringDto> ApiRequests { get; }
        void Handle();
    }
}
