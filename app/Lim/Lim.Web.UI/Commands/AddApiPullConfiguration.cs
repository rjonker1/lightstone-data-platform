using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Commands
{
    public class AddApiPullConfiguration
    {
        public readonly PullConfiguration Configuration;

        public AddApiPullConfiguration(PullConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}