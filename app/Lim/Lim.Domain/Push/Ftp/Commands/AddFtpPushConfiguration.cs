using Lim.Domain.Push.Ftp.Database;

namespace Lim.Domain.Push.Ftp.Commands
{
    public class AddFtpPushConfiguration : Command
    {
        public AddFtpPushConfiguration(PushFtpDatabaseConfiguration configuration)
        {
            Configuration = configuration;
        }

        public readonly PushFtpDatabaseConfiguration Configuration;
    }
}
