using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.UnitOfWork;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Lace.Toolbox.Database.Repositories;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_metrics : Specification
    {
        private readonly IReadOnlyRepository _repository;
        private readonly IGetMetrics _getMetrics;
        private readonly IHaveCarInformation _request;

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
