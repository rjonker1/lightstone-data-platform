using System.Collections.Generic;
using System.Linq;
using Lim.Domain.Dto;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;
using Lim.Test.Helper.Mothers;

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

        private void SetConfigurations(IEnumerable<ApiPushConfigurationDto> configs)
        {
            

        }

        public bool HasConfiguration { get; private set; }
        public IEnumerable<ApiPushIntegration> Configurations { get; private set; }
    }
}
