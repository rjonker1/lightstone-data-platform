using System.Collections.Generic;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Core.Contracts.Services
{
    public interface ICallMonitoringService
    {
        List<DataProviderDto> GetMonitoringForDataProviders();
        List<DataProviderStatisticsDto> GetDataProviderStatistics();
        List<ApiRequestMonitoringDto> GetApiRequests();
    }
}
