using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Domain.DataProviders.Lightstone.Services.Specifics;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Lace.Test.Helper.Mothers.Sources.Lightstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_total_sales_by_age_metrics : Specification
    {
        private readonly IRetrieveATypeOfMetric<TotalSalesByAgeModel> _metric;

        public when_getting_total_sales_by_age_metrics()
        {
            var request = LaceRequestCarInformationRequestBuilder.ForCarId_107483();
            var stats = StatisticsData.ForCarId(); //MetricsBuilder.GetStatistics();
            var bands = MetricsBuilder.GetBands();

            _metric = new TotalSalesByAgeMetric(request, stats, bands);
        }

        public override void Observe()
        {
            _metric.Get();
        }

        [Observation]
        public void lightstone_total_sales_by_age_metric_should_exist()
        {
            _metric.MetricResult.Count.ShouldNotEqual(0);
        }
    }
}
