using System.Linq;
using Lace.Models.Lightstone.DataObject;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Metrics.Specifics;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_accident_distribution_metrics : Specification
    {
        private readonly IRetrieveATypeOfMetric<AccidentDistributionModel> _metric;

        public when_getting_accident_distribution_metrics()
        {
            var stats = MetricsBuilder.GetStatistics();
            var bands = MetricsBuilder.GetBands();
            _metric = new AccidentDistributionMetric(stats, bands);
        }

        public override void Observe()
        {
            _metric.Get();
        }

        [Observation]
        public void lightstone_accident_distribution_result_should_exist()
        {
            _metric.MetricResult.ShouldNotBeNull();
            _metric.MetricResult.Count.ShouldNotEqual(0);
        }

        [Observation]
        public void lightstone_accident_distribution_gauge_front_band_metric_value_must_be_valid()
        {
            var frontGauge = _metric.MetricResult.FirstOrDefault(w => w.Band == "Front");

            frontGauge.ShouldNotBeNull();
            frontGauge.Value.ShouldEqual(52.85);
        }

        [Observation]
        public void lightstone_accident_distribution_gauge_side_band_metric_value_must_be_valid()
        {
            var sideGauge = _metric.MetricResult.FirstOrDefault(w => w.Band == "Side");
            sideGauge.ShouldNotBeNull();

            sideGauge.Value.ShouldEqual(21.13);
        }

        [Observation]
        public void lightstone_accident_distribution_gauge_rear_band_metric_value_must_be_valid()
        {
            var bandGauge = _metric.MetricResult.FirstOrDefault(w => w.Band == "Rear");
            bandGauge.ShouldNotBeNull();

            bandGauge.Value.ShouldEqual(26.02);
        }
    }
}
