using System.Collections.Generic;
using Lim.Domain.Dto;
using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Commands
{
    public class GetAllConfigurations
    {
        public GetAllConfigurations()
        {
        }

        public void Set(IEnumerable<ConfigurationDto> configurations)
        {
            Configurations = configurations;
        }

        public IEnumerable<ConfigurationDto> Configurations { get; private set; } 
    }

    public class GetApiPushConfiguration
    {
        public readonly long ConfigurationId;
        public readonly long ClientId;

        public GetApiPushConfiguration(long configurationId, long clientId)
        {
            ConfigurationId = configurationId;
            ClientId = clientId;
        }

        public void Set(IEnumerable<PushConfigurationView> configuration)
        {
            Configuration = configuration;
        }

        public IEnumerable<PushConfigurationView> Configuration { get; private set; }
    }

    public class GetApiPullConfiguration
    {
        public readonly long ConfigurationId;

        public GetApiPullConfiguration(long configurationId)
        {
            ConfigurationId = configurationId;
        }
    }
}