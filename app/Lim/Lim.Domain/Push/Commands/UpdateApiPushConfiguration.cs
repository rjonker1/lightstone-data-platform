namespace Lim.Domain.Push.Commands
{
    public class UpdateApiPushConfiguration : Command
    {
        public readonly PushConfiguration Configuration;

        public UpdateApiPushConfiguration(PushConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}