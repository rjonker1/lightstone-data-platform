using System.Collections.Generic;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Metrics
{
    public class BaseLevelMetrics : IHaveAllTheMetrics
    {
        public IEnumerable<IHaveMetricForRetrieval> Metrics { get; private set; }
        private readonly IEnumerable<Statistic> _statisticsData;

        public BaseLevelMetrics(IEnumerable<Statistic> statistics,IEnumerable<IHaveMetricForRetrieval> baseRetrievalMetrics)
        {
            _statisticsData = statistics;
            Metrics = baseRetrievalMetrics;
        }

        public void AddMetrics()
        {
            
        }
    }
}
