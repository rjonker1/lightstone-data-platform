namespace Lim.Domain.Push.Commands
{
    public class GetApiPushConfiguration : Command
    {
        public readonly long ConfigurationId;
        public readonly long ClientId;

        public GetApiPushConfiguration(long configurationId, long clientId)
        {
            ConfigurationId = configurationId;
            ClientId = clientId;
        }

        public void Set(PushConfigurationView configuration)
        {
            Configuration = configuration;
        }

        public PushConfigurationView Configuration { get; private set; }
    }
}
