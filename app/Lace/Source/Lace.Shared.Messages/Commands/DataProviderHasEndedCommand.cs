using System;
namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderHasEndedCommand
    {
        public DataProviderCommandDto Command { get; private set; }

        public DataProviderHasEndedCommand(DataProviderCommandDto command)
        {
            Command = command;
        }
    }
}
