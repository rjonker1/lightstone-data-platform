using System.Linq;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Domain.DataProviders.Lightstone.Services.Specifics;
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

        [Observation]
        public void lightstone_image_gauge_max_speed_metric_values_must_be_valid()
        {
            var maxSpeedGauge = _metric.MetricResult.FirstOrDefault(w => w.GaugeName == "Max Speed");

            maxSpeedGauge.ShouldNotBeNull();

            maxSpeedGauge.MaxValue.ShouldEqual(238.0);
            maxSpeedGauge.MinValue.ShouldEqual(155.0);
            maxSpeedGauge.Quarter.ShouldEqual(3.0);
            maxSpeedGauge.Value.ShouldEqual(190.0);
        }

        [Observation]
        public void lightstone_image_gauge_acceleration_metric_values_must_be_valid()
        {
            var accelerationGauge = _metric.MetricResult.FirstOrDefault(w => w.GaugeName == "Acceleration");

            accelerationGauge.ShouldNotBeNull();

            accelerationGauge.MaxValue.ShouldEqual(6.8);
            accelerationGauge.MinValue.ShouldEqual(15.7);
            accelerationGauge.Quarter.ShouldEqual(3.0);
            accelerationGauge.Value.ShouldEqual(10.4);
        }

        [Observation]
        public void lightstone_image_gauge_kw_metric_values_must_be_valid()
        {
            var kwGauge = _metric.MetricResult.FirstOrDefault(w => w.GaugeName == "kW");
            kwGauge.ShouldNotBeNull();

            kwGauge.MaxValue.ShouldEqual(155.0);
            kwGauge.MinValue.ShouldEqual(54.0);
            kwGauge.Quarter.ShouldEqual(4.0);
            kwGauge.Value.ShouldEqual(91.0);
        }

        [Observation]
        public void lightstone_image_gauge_torque_metric_values_must_be_valid()
        {
            var torqueGauge = _metric.MetricResult.FirstOrDefault(w => w.GaugeName == "Torque");
            torqueGauge.ShouldNotBeNull();

            torqueGauge.MaxValue.ShouldEqual(320.0);
            torqueGauge.MinValue.ShouldEqual(108.0);
            torqueGauge.Quarter.ShouldEqual(4.0);
            torqueGauge.Value.ShouldEqual(157.0);
        }

        [Observation]
        public void lightstone_image_gauge_C02_metric_values_must_be_valid()
        {
            var c02Gauge = _metric.MetricResult.FirstOrDefault(w => w.GaugeName == "CO2");
            c02Gauge.ShouldNotBeNull();

            c02Gauge.MaxValue.ShouldEqual(117.0);
            c02Gauge.MinValue.ShouldEqual(194.0);
            c02Gauge.Quarter.ShouldEqual(2.0);
            c02Gauge.Value.ShouldEqual(166.0);
        }

    }
}
