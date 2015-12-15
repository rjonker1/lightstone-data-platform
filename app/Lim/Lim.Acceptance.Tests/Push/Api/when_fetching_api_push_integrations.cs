using System.Collections.Generic;
using System.Linq;
using Lim.Core;
using Lim.Domain.Entities.Repository;
using Lim.Enums;
using Lim.Schedule.Core.Audits;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Factories.Api;
using Lim.Schedule.Core.Identifiers;
using Lim.Schedule.Core.Tracking;
using Xunit.Extensions;

namespace Lim.Acceptance.Tests.Push.Api
{
    public class when_fetching_api_push_integrations : AbstractTest
    {
        private readonly IFetch<FetchConfigurationCommand, IEnumerable<ApiPushIntegration>> _fetchFactory;
        private readonly IRepository _repository;
        private readonly IPush<ApiInitializePushCommand> _pusher;
        private FetchConfigurationCommand _command;

        public when_fetching_api_push_integrations() : base()
        {
            _repository = new LimRepository();
            _pusher = new PushFactory(new InitializePushFactory(_repository), new TrackIntegration(_repository),
                new StoreIntegrationAudit(_repository));

            _fetchFactory = new FetchPushFactory(_repository, _pusher);
        }

        public override void Observe()
        {

        }

        [Observation]
        public void then_api_push_every_minute_integrations_should_be_retrieved()
        {
            _command = new FetchConfigurationCommand(IntegrationAction.Push, IntegrationType.Api, Frequency.EveryMinute);
            var integrations = _fetchFactory.Fetch(_command);
            integrations.ShouldNotBeNull();
            integrations.Count().ShouldEqual(1);
        }
    }
}
