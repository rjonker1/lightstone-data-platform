using System.Linq;
using Lim.Domain.Client.Commands;
using Lim.Domain.Client.Handlers;
using Lim.Domain.Entities.Repository;
using Lim.Domain.Push.Commands;
using Lim.Web.UI.Handlers;
using Xunit.Extensions;

namespace Lim.Acceptance.Tests.Integrations.Configurations
{
    public class when_handling_configurations : AbstractTest
    {
        private readonly IHandleGettingConfiguration _handler;

        public when_handling_configurations()
        {

            _handler = new GetConfigurationHandler(new LimRepository());
        }

        public override void Observe()
        {

        }

        [Observation]
        public void then_api_push_configuration_should_be_handled()
        {
            var command = new GetAllConfigurations();
            _handler.Handle(command);
            command.Configurations.ShouldNotBeNull();
            command.Configurations.Count().ShouldNotEqual(0);
            command.Configurations.FirstOrDefault().IntegrationClients.ShouldNotBeNull();
            command.Configurations.FirstOrDefault().IntegrationClients.Count().ShouldNotEqual(0);
            command.Configurations.FirstOrDefault().IntegrationPackages.ShouldNotBeNull();
            command.Configurations.FirstOrDefault().IntegrationPackages.Count().ShouldNotEqual(0);
            command.Configurations.FirstOrDefault().IntegrationContracts.ShouldNotBeNull();
            command.Configurations.FirstOrDefault().IntegrationContracts.Count().ShouldNotEqual(0);


            var configOnlyCommand = new GetApiPushConfiguration(command.Configurations.FirstOrDefault().Id,
                command.Configurations.FirstOrDefault().ClientId);
            _handler.Handle(configOnlyCommand);
            configOnlyCommand.ApiConfiguration.ShouldNotBeNull();
            configOnlyCommand.ApiConfiguration.Configuration.IntegrationPackages.ShouldNotBeNull();
            configOnlyCommand.ApiConfiguration.Configuration.IntegrationClients.ShouldNotBeNull();
            configOnlyCommand.ApiConfiguration.Configuration.IntegrationContracts.ShouldNotBeNull();
        }
    }
}
