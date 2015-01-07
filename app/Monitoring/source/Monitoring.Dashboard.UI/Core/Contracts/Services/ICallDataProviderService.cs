using System.Collections.Generic;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Core.Contracts.Services
{
    public interface ICallDataProviderService
    {
        IEnumerable<DataProviderResponseDto> GetDataProviderMonitoringInformation();
    }
}
