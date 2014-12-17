using System;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderResponseTransformedCommand
    {
        public DataProviderCommandDto Command { get; private set; }

        public DataProviderResponseTransformedCommand(DataProviderCommandDto command)
        {
            Command = command;
        }

        public DataProviderResponseTransformedCommand()
        {
            
        }
    }
}
