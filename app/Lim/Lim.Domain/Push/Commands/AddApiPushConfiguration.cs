namespace Lim.Domain.Push.Commands
{
    public class AddApiPushConfiguration : Command
    {
        public readonly PushApiDataPlatformConfiguration ApiDataPlatformConfiguration;

        public AddApiPushConfiguration(PushApiDataPlatformConfiguration apiDataPlatformConfiguration)
        {
            ApiDataPlatformConfiguration = apiDataPlatformConfiguration;
        }
    }
}