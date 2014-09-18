using Lace.Models.Lightstone.DataObject;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Metrics.Specifics;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_auction_factor_metric : Specification
    {
        private readonly IRetrieveATypeOfMetric<AuctionFactorModel> _metric;

        public when_getting_auction_factor_metric()
        {
            var request = LaceRequestCarInformationRequestBuilder.ForCarId_107483();
            var stats = MetricsBuilder.GetStatistics();
            var makes = MetricsBuilder.GetMakes();
            _metric = new AuctionFactorsMetric(request, stats, makes);
        }

        public override void Observe()
        {
            _metric.Get();
        }

        [Observation]
        public void lightstone_auction_factor_metrics_should_not_exist()
        {
            _metric.MetricResult.Count.ShouldEqual(0);
        }
    }
}
