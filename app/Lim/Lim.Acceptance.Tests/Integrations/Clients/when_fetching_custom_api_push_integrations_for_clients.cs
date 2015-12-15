using System;
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

namespace Lim.Acceptance.Tests.Integrations.Clients
{
    public class when_fetching_custom_api_push_integrations_for_clients : AbstractTest
    {
        private readonly IFetch<FetchConfigurationForCustomCommand, IEnumerable<ApiPushIntegration>> _fetcher;
        private readonly IRepository _repository;
        private readonly FetchConfigurationForCustomCommand _command;

        public when_fetching_custom_api_push_integrations_for_clients()
        {
            _command = new FetchConfigurationForCustomCommand(IntegrationAction.Push, IntegrationType.Api, Frequency.Custom,DateTime.Now.ToString("dddd"));
            _repository = new LimRepository();
            _fetcher = new CustomFetchPushFactory(_repository,
                new PushFactory(new InitializePushFactory(_repository), new TrackIntegration(_repository), new StoreIntegrationAudit(_repository)));
        }

        public override void Observe()
        {
            
        }

        [Observation]
        public void then_api_push_integration_for_custom_integration_must_have_correct_values()
        {
            var configurations = _fetcher.Fetch(_command);
            configurations.ShouldNotBeNull();
            configurations.Count().ShouldNotEqual(0);
        }
    }
}
