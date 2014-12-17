using System;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderHasBeenConfiguredCommand
    {
        public DataProviderCommandDto Command { get; private set; }

        public DataProviderHasBeenConfiguredCommand(DataProviderCommandDto command)
        {
            Command = command;
        }

        public DataProviderHasBeenConfiguredCommand()
        {
        }
    }
}
