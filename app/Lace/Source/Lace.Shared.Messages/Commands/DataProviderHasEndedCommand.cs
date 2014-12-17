using System;
namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderHasEndedCommand
    {
        public DataProviderCommandDto DataProviderCommand { get; private set; }

        public DataProviderHasEndedCommand(DataProviderCommandDto command)
        {
            DataProviderCommand = command;
        }
    }
}
