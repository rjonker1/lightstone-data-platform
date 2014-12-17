using System;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderHasExecutedCommand
    {
        public DataProviderCommandDto Command { get; private set; }

        public DataProviderHasExecutedCommand(DataProviderCommandDto command)
        {
            Command = command;
        }
    }
}
