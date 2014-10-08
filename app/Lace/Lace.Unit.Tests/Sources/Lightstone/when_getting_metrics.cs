using System.Linq;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.UnitOfWork;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_metrics : Specification
    {
        private readonly IReadOnlyRepository<Metric> _repository;
        private readonly IGetMetrics _getMetrics;
        private readonly IProvideCarInformationForRequest _request;

        public when_getting_metrics()
        {
            _repository = new FakeMetricRepository();
            _getMetrics = new MetricUnitOfWork(_repository);
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
