using System.Collections.Generic;
using Lim.Dtos;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Test.Helper.Fakes.Handlers
{
    public class FakeFetchingApiPushConfigurationHandler : IHandleFetchingApiPushConfiguration
    {
        public void Handle(FetchConfigurationCommand command)
        {
           

        }

        public void Handle(FetchConfigurationForClientCommand command)
        {
           

        }

        public void Handle(FetchConfigurationForCustomCommand command)
        {
           

        }

        private void SetConfigurations(IEnumerable<ConfigurationApiDto> configs)
        {
            

        }

        public bool HasConfiguration { get; private set; }
        public IEnumerable<ApiPushIntegration> Configurations { get; private set; }
    }
}
