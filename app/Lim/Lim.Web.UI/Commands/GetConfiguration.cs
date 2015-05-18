using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Commands
{
    public class GetConfiguration
    {
        public GetConfiguration(long configurationId)
        {
            ConfigurationId = configurationId;
        }

        public readonly long ConfigurationId;
    }

    public class GetApiPushConfiguration
    {
        public GetApiPushConfiguration(long configurationId)
        {
            ConfigurationId = configurationId;
        }

        public void Set(PushConfigurationView configuration)
        {
            Configuration = configuration;
        }

        public readonly long ConfigurationId;
        public PushConfigurationView Configuration { get; private set; }
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