using System.Collections.Generic;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Core.Contracts.Repositories
{
    public interface IDataProviderRepository
    {
        IEnumerable<DataProviderResponseDto> GetAllDataProviderInformation();
    }
}
