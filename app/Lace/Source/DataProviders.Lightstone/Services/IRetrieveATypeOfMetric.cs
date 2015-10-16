using System.Collections.Generic;
using Lace.Toolbox.Database.Dtos;

namespace Lace.Domain.DataProviders.Lightstone.Services
{
    public interface IRetrieveATypeOfMetric<T>
    {
        List<T> MetricResult { get; }
        IEnumerable<StatisticDto> Statistics { get; }
        IRetrieveATypeOfMetric<T> Get();
    }
}
