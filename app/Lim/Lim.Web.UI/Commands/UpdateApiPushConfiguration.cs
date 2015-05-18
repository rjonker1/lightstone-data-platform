using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Commands
{
    public class UpdateApiPushConfiguration
    {
        public readonly PushConfiguration Configuration;

        public UpdateApiPushConfiguration(PushConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}