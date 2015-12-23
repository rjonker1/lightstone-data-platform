using Lim.Dtos;
namespace Lim.Domain.Push.Ftp.Commands
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

        public void Set(ConfigurationFtpDto configuration)
        {
            FtpConfiguration = configuration;
        }

        public ConfigurationFtpDto FtpConfiguration { get; private set; }
    }
}