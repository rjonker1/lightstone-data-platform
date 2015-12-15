using System.Linq;
using Lim.Domain.Client.Handlers;
using Lim.Domain.Entities.Repository;
using Lim.Domain.Lookup.Commands;
using Lim.Web.UI.Handlers;
using Xunit.Extensions;

namespace Lim.Acceptance.Tests.Integrations.Configurations
{
    public class when_handling_lookup_types : AbstractTest
    {
        private readonly IHandleGettingConfiguration _handler;

        public when_handling_lookup_types()
        {
            
            _handler = new GetConfigurationHandler(new LimRepository());
        }

        public override void Observe()
        {
            
        }

        [Observation]
        public void then_authentications_types_should_be_valid()
        {
            var command = new GetAuthenticationTypes();
            _handler.Handle(command);

            command.Authentication.ShouldNotBeNull();
            command.Authentication.Count().ShouldNotEqual(0);
            command.Authentication.Count().ShouldEqual(3);
        }

        [Observation]
        public void then_frequency_types_should_be_valid()
        {
            var command = new GetFrequencyTypes();
            _handler.Handle(command);

            command.Frequency.ShouldNotBeNull();
            command.Frequency.Count().ShouldNotEqual(0);
            command.Frequency.Count().ShouldEqual(5);
        }
    }
}
