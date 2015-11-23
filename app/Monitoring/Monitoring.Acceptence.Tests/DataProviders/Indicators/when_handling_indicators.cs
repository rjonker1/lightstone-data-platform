using System.Linq;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider;
using Monitoring.Dashboard.UI.Infrastructure.Handlers;
using Monitoring.Domain.Mappers;
using Monitoring.Domain.Repository;
using Shared.BuildingBlocks.AdoNet.Repository;
using Xunit.Extensions;

namespace Monitoring.Acceptance.Tests.DataProviders.Indicators
{
    public class when_handling_indicators : Specification
    {
        private readonly IHandleDataProviderIndicators _handler;
        private readonly IMonitoringRepository _repository;
        private DataProviderIndicatorsDto _indicators;

        public when_handling_indicators()
        {
            _repository = new MonitoringRepository(new RepositoryMapper(new MappingForMonitoringTypes()));
            _handler = new DataProviderIndicatorsHandler(_repository);
        }

        public override void Observe()
        {
            _handler.Handle();
            _indicators = _handler.Indicators;
        }

        [Observation]
        public void then_indicators_should_exist()
        {
            _indicators.RequestLevel.ShouldNotBeNull();
            _indicators.RequestPerDataProvider.Any().ShouldBeTrue();
        }
    }
}
