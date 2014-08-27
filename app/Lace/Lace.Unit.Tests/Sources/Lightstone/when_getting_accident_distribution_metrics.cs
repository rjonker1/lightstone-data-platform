using Lace.Models.Lightstone.Dto;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Metrics.Specifics;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_accident_distribution_metrics : Specification
    {
        private readonly IRetrieveATypeOfMetric<AccidentDistributionModel> _accidentDistributionMetrics;

        public when_getting_accident_distribution_metrics()
        {
            var stats = MetricsBuilder.GetStatistics();
            var bands = MetricsBuilder.GetBands();
            _accidentDistributionMetrics = new AccidentDistributionMetric(stats, bands);
        }

        public override void Observe()
        {
            _accidentDistributionMetrics.Get();
        }

        [Observation]
        public void lightstone_accident_distribution_result_should_exist()
        {
            _accidentDistributionMetrics.MetricResult.ShouldNotBeNull();
            _accidentDistributionMetrics.MetricResult.Count.ShouldNotEqual(0);
        }
    }
}
