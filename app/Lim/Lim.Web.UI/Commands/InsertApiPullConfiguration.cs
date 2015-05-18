using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Commands
{
    public class InsertApiPullConfiguration
    {
        public readonly PullConfiguration Configuration;

        public InsertApiPullConfiguration(PullConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}