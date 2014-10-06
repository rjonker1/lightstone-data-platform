using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.Services
{
    public interface IRetrieveATypeOfMetric<T>
    {
        List<T> MetricResult { get; }
        IEnumerable<Statistic> Statistics { get; }
        IRetrieveATypeOfMetric<T> Get();
    }
}
