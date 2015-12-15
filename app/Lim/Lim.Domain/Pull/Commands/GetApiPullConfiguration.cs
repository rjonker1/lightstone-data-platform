namespace Lim.Domain.Pull.Commands
{
    public class GetApiPullConfiguration : Command
    {
        public readonly long ConfigurationId;

        public GetApiPullConfiguration(long configurationId)
        {
            ConfigurationId = configurationId;
        }
    }
}