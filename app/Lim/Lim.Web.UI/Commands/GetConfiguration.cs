using System;
using System.Collections.Generic;
using Lim.Domain.Models;
using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Commands
{
    public class GetAllConfigurations
    {
        public GetAllConfigurations()
        {
        }

        public void Set(IEnumerable<Configuration> configurations)
        {
            Configurations = configurations;
        }

        public IEnumerable<Configuration> Configurations { get; private set; } 
    }

    public class GetApiPushConfiguration
    {
        public readonly long ConfigurationId;
        public readonly Guid ClientId;

        public GetApiPushConfiguration(long configurationId, Guid clientId)
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