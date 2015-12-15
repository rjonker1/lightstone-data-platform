namespace Lim.Domain.Push.Commands
{
    public class AddApiPushConfiguration : Command
    {
        public readonly PushConfiguration Configuration;

        public AddApiPushConfiguration(PushConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}