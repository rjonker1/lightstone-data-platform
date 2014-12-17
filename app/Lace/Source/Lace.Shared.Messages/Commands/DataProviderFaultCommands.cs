using System;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderHasFaultCommand
    {
        public DataProviderCommandDto Command { get; private set; }

        public DataProviderHasFaultCommand(DataProviderCommandDto command)
        {
            Command = command;
        }

        public DataProviderHasFaultCommand()
        {
        }
    }
}
