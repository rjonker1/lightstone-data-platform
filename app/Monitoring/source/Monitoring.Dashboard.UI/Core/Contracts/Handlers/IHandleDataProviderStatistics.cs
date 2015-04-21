using System.Collections.Generic;
using Monitoring.Dashboard.UI.Core.Models;

namespace Monitoring.Dashboard.UI.Core.Contracts.Handlers
{
    public interface IHandleDataProviderStatistics
    {
        IEnumerable<DataProviderStatisticsView> StatisticsResponse { get; }
        void Handle();
    }
}
