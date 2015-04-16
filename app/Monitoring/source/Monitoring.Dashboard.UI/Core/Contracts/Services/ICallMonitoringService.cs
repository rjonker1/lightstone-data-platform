using System.Collections.Generic;
using Monitoring.Dashboard.UI.Core.Models;

namespace Monitoring.Dashboard.UI.Core.Contracts.Services
{
    public interface ICallMonitoringService
    {
        IEnumerable<MonitoringDataProvider> GetMonitoringForDataProviders();
    }
}
