namespace Lim.Domain.Push.Commands
{
    public class GetFtpPushConfiguration : Command
    {
        public readonly long ConfigurationId;
        public readonly long ClientId;

        public GetFtpPushConfiguration(long configurationId, long clientId)
        {
            ConfigurationId = configurationId;
            ClientId = clientId;
        }
    }
}
