namespace Lim.Domain.Pull.Commands
{
    public class AddApiPullConfiguration : Command
    {
        public readonly PullConfiguration Configuration;

        public AddApiPullConfiguration(PullConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
