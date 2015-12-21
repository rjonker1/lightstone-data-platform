namespace Lim.Domain.Push.Commands
{
    public class UpdateApiPushConfiguration : Command
    {
        public readonly PushApiDataPlatformConfiguration ApiDataPlatformConfiguration;

        public UpdateApiPushConfiguration(PushApiDataPlatformConfiguration apiDataPlatformConfiguration)
        {
            ApiDataPlatformConfiguration = apiDataPlatformConfiguration;
        }
    }
}