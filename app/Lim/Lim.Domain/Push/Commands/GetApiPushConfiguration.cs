using Lim.Dtos;

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

        public void Set(ConfigurationApiDto apiConfiguration)
        {
            ApiConfiguration = apiConfiguration;
        }

        public ConfigurationApiDto ApiConfiguration { get; private set; }
    }
}
