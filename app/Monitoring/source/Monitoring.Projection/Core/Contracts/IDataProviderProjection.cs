using Monitoring.Projection.Core.Models.DataProviders;

namespace Monitoring.Projection.Core.Contracts
{
    public interface IDataProviderProjection : IProjection
    {
        DataProviderPerformanceDto[] ShowPerformanceResults(int categoryId);
    }
}
