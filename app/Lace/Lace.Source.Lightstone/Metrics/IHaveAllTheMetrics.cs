using System.Collections.Generic;

namespace Lace.Source.Lightstone.Metrics
{
    public interface IHaveAllTheMetrics
    {
        IEnumerable<IHaveMetricForRetrieval> Metrics { get; } 
    }
}
