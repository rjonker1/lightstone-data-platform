using System.Collections.Generic;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Core.Contracts.Handlers
{
    public interface IHandleDataProviderStatistics
    {
        List<DataProviderStatisticsDto> StatisticsResponse { get; }
        void Handle();
    }
}
