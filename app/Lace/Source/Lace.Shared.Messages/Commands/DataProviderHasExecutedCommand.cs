using System;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderHasExecutedCommand
    {
        public DataProviderCommandDto DataProviderCommand { get; private set; }

        public DataProviderHasExecutedCommand(DataProviderCommandDto command)
        {
            DataProviderCommand = command;
        }
    }
}
