using System;
using System.Collections.Generic;
using Monitoring.Dashboard.UI.Core.Models;

namespace Monitoring.Dashboard.UI.Core.Contracts.Services
{
    public interface ICallMonitoringService
    {
        IEnumerable<MonitoringResponse> GetMonitoringInformationBySource(int source);
        IEnumerable<MonitoringResponse> GetMonitoringSummaryBySource(int source);
        MonitoringResponse GetMonitoringResponseItem(Guid id, int source);
    }
}
