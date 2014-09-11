using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.DataObjects;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_metrics : Specification
    {
        private readonly IReadOnlyRepository<Metric> _repository;
        private readonly IGetMetrics _getMetrics;
        private readonly ILaceRequestCarInformation _request;

        public when_getting_metrics()
        {
            _repository = new FakeMetricRepository();
            _getMetrics = new MetricData(_repository);
            _request = LaceRequestCarInformationRequestBuilder.ForCarId_107483();
        }

        public override void Observe()
        {
            _getMetrics.GetMetrics(_request);
        }

        [Observation]
        public void lightstone_metrics_must_exist()
        {
            _getMetrics.Metrics.ShouldNotBeNull();
            _getMetrics.Metrics.Count().ShouldNotEqual(0);
        }
    }
}
