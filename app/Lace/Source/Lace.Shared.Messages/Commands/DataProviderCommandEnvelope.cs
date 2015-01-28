using System;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class ExecutingDataProviderMonitoringCommand
    {
        public CommandDto Command { get; private set; }

        public ExecutingDataProviderMonitoringCommand(CommandDto command)
        {
            Command = command;
        }

        public ExecutingDataProviderMonitoringCommand()
        {
        }
    }
}
