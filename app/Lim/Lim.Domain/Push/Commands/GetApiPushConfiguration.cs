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

        public void Set(PushApiConfigurationView apiConfiguration)
        {
            ApiConfiguration = apiConfiguration;
        }

        public PushApiConfigurationView ApiConfiguration { get; private set; }
    }
}
