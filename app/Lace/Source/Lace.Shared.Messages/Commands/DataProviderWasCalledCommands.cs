using System;
namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderWasCalledCommand
    {
        public DataProviderCommandDto Command { get; private set; }

        public DataProviderWasCalledCommand(DataProviderCommandDto command)
        {
            Command = command;
        }
    }
}
