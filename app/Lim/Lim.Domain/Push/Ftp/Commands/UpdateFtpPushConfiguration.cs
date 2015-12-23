using Lim.Domain.Push.Ftp.Database;

namespace Lim.Domain.Push.Ftp.Commands
{
    public class UpdateFtpPushConfiguration : Command
    {
        public UpdateFtpPushConfiguration(PushFtpDatabaseConfiguration configuration)
        {
            Configuration = configuration;
        }

        public readonly PushFtpDatabaseConfiguration Configuration;
    }
}