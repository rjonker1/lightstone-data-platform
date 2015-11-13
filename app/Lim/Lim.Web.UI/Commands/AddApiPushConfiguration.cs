using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Commands
{
    public class AddApiPushConfiguration
    {
        public readonly PushConfiguration Configuration;

        public AddApiPushConfiguration(PushConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}