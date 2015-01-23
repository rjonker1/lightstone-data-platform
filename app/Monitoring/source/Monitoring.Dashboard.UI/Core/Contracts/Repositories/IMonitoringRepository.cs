using System;
using System.Collections.Generic;
using Monitoring.Dashboard.UI.Core.Models;

namespace Monitoring.Dashboard.UI.Core.Contracts.Repositories
{
    public interface IMonitoringRepository
    {
        IEnumerable<MonitoringResponse> GetAllMonitoringInformation(int source);
    }
}
