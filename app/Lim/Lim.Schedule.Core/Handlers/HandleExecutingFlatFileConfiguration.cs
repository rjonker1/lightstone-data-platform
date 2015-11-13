using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Dto;
using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core.Handlers
{
    public class HandleExecutingFlatFileConfiguration : IHandleExecutingFlatFileConfiguration
    {
        private static readonly ILog Log = LogManager.GetLogger<HandleExecutingFlatFileConfiguration>();

        public HandleExecutingFlatFileConfiguration()
        {
        }

        public void Handle(ExecuteFlatFilePullConfigurationCommand command)
        {
            Log.Info("Handling Flat File Pull Configurations");

            if (command.Configurations == null || !command.Configurations.Any())
            {
                Log.Info("There are not configurations for flat file to execute");
                return;
            }

            command.Configurations.ToList().ForEach(f =>
            {
                f.Puller.Pull(f.Command);
            });

            IsHandled = true;
        }

        public void Handle(ExecuteFlatFilePushConfigurationCommand command)
        {
            Log.Info("Handling Flat File Push Configurations");
            IsHandled = false;
        }

        public bool IsHandled { get; private set; }
    }
}