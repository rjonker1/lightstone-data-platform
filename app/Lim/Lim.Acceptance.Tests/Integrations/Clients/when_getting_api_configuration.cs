using System.Collections.Generic;
using System.Linq;
using Lim.Domain.Client;
using Lim.Domain.Client.Handlers;
using Lim.Domain.Entities.Repository;
using Lim.Web.UI.Handlers;
using Xunit.Extensions;

namespace Lim.Acceptance.Tests.Integrations.Clients
{
    public class when_getting_api_configuration : AbstractTest
    {
        private List<ApiConfiguration> _configurations;
        private readonly IHandleGettingIntegrationClient _handler;

        public when_getting_api_configuration()
        {
            _handler = new GetIntegrationClientHandler(new LimRepository());
        }

        public override void Observe()
        {
            _configurations = ApiConfiguration.Get(_handler);
        }

        [Observation]
        public void then_api_configurations_should_exist_for_client()
        {
            _configurations.ShouldNotBeNull();
            _configurations.FirstOrDefault().Client.ShouldNotBeNull();
            _configurations.FirstOrDefault().Client.Configurations.ShouldNotBeNull();
            _configurations.FirstOrDefault().Client.Configurations.Count.ShouldNotEqual(0);

        }
    }
}
