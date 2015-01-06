using System.Collections.Generic;
using Monitoring.Projection.UI.Infrastructure.Dto;

namespace Monitoring.Projection.UI.Core.Contracts.Repositories
{
    public interface IDataProviderRepository
    {
        IEnumerable<DataProviderResponseDto> GetAllDataProviderInformation();
    }
}
