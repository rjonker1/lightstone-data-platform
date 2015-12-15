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
    public class when_fetching_api_push_integrations_for_clients : AbstractTest
    {
        private readonly IFetch<FetchConfigurationForClientCommand, IEnumerable<ApiPushIntegration>> _fetcher;
        private readonly IRepository _repository;
        private readonly FetchConfigurationForClientCommand _command;

        public when_fetching_api_push_integrations_for_clients()
        {
            //IntegrationAction.Push, IntegrationType.Api, Frequency.AlwaysOn,message.Body.ContractId, message.Body.PackageId
            _command = new FetchConfigurationForClientCommand(IntegrationAction.Push, IntegrationType.Api, Frequency.EveryMinute,
                new Guid("888FEFFD-9594-4EA4-9610-A0362E3B94CD"), new Guid("24E3E04A-4EFD-46DA-A94E-0A2004716FB3"));
            _repository = new LimRepository();
            _fetcher = new ClientFetchPushFactory(_repository,
                new PushFactory(new InitializePushFactory(_repository), new TrackIntegration(_repository), new StoreIntegrationAudit(_repository)));
        }

        public override void Observe()
        {
            
        }

        [Observation]
        public void then_api_push_integration_for_daily_integration_must_have_correct_values()
        {
            var configurations = _fetcher.Fetch(_command);
            configurations.ShouldNotBeNull();
            configurations.Count().ShouldNotEqual(0);
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
