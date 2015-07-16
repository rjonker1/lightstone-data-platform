using System.Linq;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Domain.DataProviders.Lightstone.Services.Specifics;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_repair_index_metrics : Specification
    {
        private readonly IRetrieveATypeOfMetric<RepairIndexModel> _metric;

        public when_getting_repair_index_metrics()
        {
            var stats = MetricsBuilder.GetStatistics();
            var bands = MetricsBuilder.GetBands();
            var request = LaceRequestCarInformationRequestBuilder.ForCarId_107483();
            _metric = new RepairIndexMetric(request, stats, bands);
        }


        public override void Observe()
        {
            _metric.Get();
        }

        [Observation]
        public void lightstone_repair_index_metric_result_should_exist()
        {
            _metric.MetricResult.ShouldNotBeNull();
            _metric.MetricResult.Count.ShouldNotEqual(0);
        }

        [Observation]
        public void lightstone_repair_index_metric_p1_band_should_be_valid()
        {
            var p1Band = _metric.MetricResult.FirstOrDefault(w => w.Band == "p1");

            p1Band.Value.ShouldEqual(16.35);
            p1Band.Year.ShouldEqual(2008);
        }

        [Observation]
        public void lightstone_repair_index_metric_p5_band_should_be_valid()
        {
            var p5Band = _metric.MetricResult.FirstOrDefault(w => w.Band == "p5");

            p5Band.Value.ShouldEqual(20.74);
            p5Band.Year.ShouldEqual(2008);
        }

        [Observation]
        public void lightstone_repair_index_metric_p10_band_should_be_valid()
        {
            var p10Band = _metric.MetricResult.FirstOrDefault(w => w.Band == "p10");

            p10Band.Value.ShouldEqual(28.01);
            p10Band.Year.ShouldEqual(2008);
        }

        [Observation]
        public void lightstone_repair_index_metric_p25_band_should_be_valid()
        {
            var p25Band = _metric.MetricResult.FirstOrDefault(w => w.Band == "p25");

            p25Band.Value.ShouldEqual(44.27);
            p25Band.Year.ShouldEqual(2008);
        }

        [Observation]
        public void lightstone_repair_index_metric_p50_band_should_be_valid()
        {
            var p50Band = _metric.MetricResult.FirstOrDefault(w => w.Band == "p50");

            p50Band.Value.ShouldEqual(59.36);
            p50Band.Year.ShouldEqual(2008);
        }

        [Observation]
        public void lightstone_repair_index_metric_p75_band_should_be_valid()
        {
            var p75Band = _metric.MetricResult.FirstOrDefault(w => w.Band == "p75");

            p75Band.Value.ShouldEqual(69.27);
            p75Band.Year.ShouldEqual(2008);
        }

        [Observation]
        public void lightstone_repair_index_metric_p90_band_should_be_valid()
        {
            var p90Band = _metric.MetricResult.FirstOrDefault(w => w.Band == "p90");

            p90Band.Value.ShouldEqual(94.72);
            p90Band.Year.ShouldEqual(2008);
        }

        [Observation]
        public void lightstone_repair_index_metric_p95_band_should_be_valid()
        {
            var p95Band = _metric.MetricResult.FirstOrDefault(w => w.Band == "p95");

            p95Band.Value.ShouldEqual(116.41);
            p95Band.Year.ShouldEqual(2008);
        }

        [Observation]
        public void lightstone_repair_index_metric_p99_band_should_be_valid()
        {
            var p99Band = _metric.MetricResult.FirstOrDefault(w => w.Band == "p99");

            p99Band.Value.ShouldEqual(145.84);
            p99Band.Year.ShouldEqual(2008);
        }
    }
}
