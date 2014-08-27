using Lace.Models.Lightstone.Dto;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Metrics.Specifics;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_image_gauge_metric : Specification
    {
        private readonly IRetrieveATypeOfMetric<ImageGaugeModel> _metric;

        public when_getting_image_gauge_metric()
        {
            var stats = MetricsBuilder.GetStatistics();
            var metrics = MetricsBuilder.GetMetrics();
            _metric = new ImageGaugesMetric(stats, metrics);
        }

        public override void Observe()
        {
            _metric.Get();
        }

        [Observation]
        public void lightstone_image_gauge_metric_result_should_exist()
        {
            _metric.MetricResult.ShouldNotBeNull();
            _metric.MetricResult.Count.ShouldNotEqual(0);
        }
    }
}
