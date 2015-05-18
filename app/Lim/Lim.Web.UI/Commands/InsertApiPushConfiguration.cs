using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Commands
{
    public class InsertApiPushConfiguration
    {
        public readonly PushConfiguration Configuration;

        public InsertApiPushConfiguration(PushConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}