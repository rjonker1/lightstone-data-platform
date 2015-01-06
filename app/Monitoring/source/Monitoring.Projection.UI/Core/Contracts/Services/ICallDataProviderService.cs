using System.Collections.Generic;
using Monitoring.Projection.UI.Infrastructure.Dto;

namespace Monitoring.Projection.UI.Core.Contracts.Services
{
    public interface ICallDataProviderService
    {
        IEnumerable<DataProviderResponseDto> GetDataProviderMonitoringInformation();
    }
}
