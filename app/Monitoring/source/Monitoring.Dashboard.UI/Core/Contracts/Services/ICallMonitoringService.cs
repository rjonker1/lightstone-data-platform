using System.Collections.Generic;
using Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider;

namespace Monitoring.Dashboard.UI.Core.Contracts.Services
{
    public interface ICallMonitoringService
    {
        List<DataProviderDto> GetMonitoringForDataProviders();
        DataProviderIndicatorsDto GetDataProviderIndicators();
    }
}
