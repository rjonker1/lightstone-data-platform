using System;
namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderExecutingCommand
    {
        public DataProviderCommandDto Command { get; private set; }

        public DataProviderExecutingCommand(DataProviderCommandDto command)
        {
            Command = command;
        }
    }
}
