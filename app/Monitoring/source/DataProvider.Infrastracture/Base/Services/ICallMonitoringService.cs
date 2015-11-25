using System.Collections.Generic;
using DataProvider.Infrastructure.Dto.DataProvider;

namespace DataProvider.Infrastructure.Base.Services
{
    public interface ICallMonitoringService
    {
        List<DataProviderDto> GetMonitoringForDataProviders();
        DataProviderIndicatorsDto GetDataProviderIndicators();
    }
}
