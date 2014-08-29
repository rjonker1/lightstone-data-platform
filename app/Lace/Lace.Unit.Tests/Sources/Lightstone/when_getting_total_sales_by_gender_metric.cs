using Lace.Models.Lightstone.Dto;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Metrics.Specifics;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Lace.Test.Helper.Mothers.Sources.Lightstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_total_sales_by_gender_metric : Specification
    {
        private readonly IRetrieveATypeOfMetric<TotalSalesByGenderModel> _metric;


        public when_getting_total_sales_by_gender_metric()
        {
            var request = LaceRequestCarInformationRequestBuilder.ForCarId_113018();
            var stats = StatisticsData.ForMetricId_7_TotalSalesByGender();
            var bands = MetricsBuilder.GetBands();
            var carTypes = MetricsBuilder.GetCarTypes();
            _metric = new TotalSalesByGenderMetric(request, stats, bands, carTypes);
        }


        public override void Observe()
        {
            _metric.Get();
        }

        [Observation]
        public void lightstone_total_sales_by_gender_metric_should_exist()
        {
            _metric.MetricResult.Count.ShouldNotEqual(0);
        }
    }
}
