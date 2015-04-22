using System.Collections.Generic;
using Monitoring.Dashboard.UI.Core.Models;

namespace Monitoring.Dashboard.UI.Core.Contracts.Services
{
    public interface ICallMonitoringService
    {
        IEnumerable<DataProviderView> GetMonitoringForDataProviders();
        IEnumerable<DataProviderStatisticsView> GetDataProviderStatistics();
    }
}
