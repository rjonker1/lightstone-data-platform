using System;
using System.Linq;
using Lim.Core;
using Lim.Domain.Client.Commands;
using Lim.Domain.Client.Handlers;
using Lim.Domain.Entities.Repository;
using Lim.Web.UI.Handlers;
using Xunit.Extensions;

namespace Lim.Acceptance.Tests.Integrations.Clients
{
    public class when_getting_integration_client : AbstractTest
    {
        private IHandleGettingIntegrationClient _handler;
        private readonly GetIntegrationClients _allClientscommand;
        private readonly GetIntegrationClient _clientCommand;
        private readonly IRepository _repository;

        public when_getting_integration_client()
        {
            _repository = new LimRepository();
            _allClientscommand = new GetIntegrationClients();
            _handler = new GetIntegrationClientHandler(new LimRepository());
        }

        public override void Observe()
        {
            _handler.Handle(_allClientscommand);
        }

        [Observation]
        public void then_all_integrations_clients_should_be_retrieved()
        {
            _allClientscommand.Clients.ShouldNotBeNull();
            _allClientscommand.Clients.Count().ShouldNotEqual(0);

            var clientId = _allClientscommand.Clients.FirstOrDefault().Id;
            var command = new GetIntegrationClient(clientId);
            _handler.Handle(command);

            command.Client.ShouldNotBeNull();
            command.Client.Id.ShouldEqual(clientId);
            command.Client.Configurations.ShouldNotBeNull();
            command.Client.Configurations.Count.ShouldNotEqual(0);
        }
    }
}
