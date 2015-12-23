using Lim.Domain.Push.Api.DataPlatform;

namespace Lim.Domain.Push.Commands
{
    public class AddApiPushConfiguration : Command
    {
        public readonly PushApiDataPlatformConfiguration ApiDataPlatformConfiguration;

        public AddApiPushConfiguration(PushApiDataPlatformConfiguration configuration)
        {
            ApiDataPlatformConfiguration = configuration;
        }
    }
}