using System.Collections.Generic;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Metrics
{
    public interface IHaveMetricForRetrieval
    {
        IEnumerable<Statistic> Statistics { get; }
        MetricTypes[] Metrics { get; }
        ILaceRequestCarInformation Request { get; }

        void GetStatistics();
    }
}
