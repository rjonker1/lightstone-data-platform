using Monitoring.Projection.Core.Models;

namespace Monitoring.Projection.Core.Contracts
{
    public interface IDataProviderProjection : IProjection
    {
        DataProviderPerformanceDto[] ShowPerformanceResults();
    }
}
