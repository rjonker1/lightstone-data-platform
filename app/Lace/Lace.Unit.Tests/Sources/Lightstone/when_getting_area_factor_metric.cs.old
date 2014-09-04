using Lace.Models.Lightstone.Dto;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Metrics.Specifics;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_area_factor_metric : Specification
    {
        private readonly IRetrieveATypeOfMetric<AreaFactorModel> _metric;

        public when_getting_area_factor_metric()
        {
            var stats = MetricsBuilder.GetStatistics();
            var muncipalities = MetricsBuilder.GetMunicipalities();
            _metric = new AreaFactorsMetric(stats, muncipalities);
        }

        public override void Observe()
        {
            _metric.Get();
        }

        [Observation]
        public void lightstone_area_factor_metric_result_should_exist()
        {
            _metric.MetricResult.ShouldNotBeNull();
            _metric.MetricResult.Count.ShouldNotEqual(0);
        }

        [Observation]
        public void lightstone_area_factor_metric_result_should_have_valid_number_of_models()
        {
            _metric.MetricResult.Count.ShouldEqual(113);
        }
    }
}
