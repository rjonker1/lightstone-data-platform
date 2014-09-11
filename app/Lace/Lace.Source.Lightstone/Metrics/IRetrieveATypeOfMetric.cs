using System.Collections.Generic;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Metrics
{
    public interface IRetrieveATypeOfMetric<T>
    {
        List<T> MetricResult { get; }
        IEnumerable<Statistic> Statistics { get; }
        IRetrieveATypeOfMetric<T> Get();
    }
}
