using System;
namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderWasCalledCommand
    {
        public DataProviderCommandDto DataProviderCommand { get; private set; }

        public DataProviderWasCalledCommand(DataProviderCommandDto command)
        {
            DataProviderCommand = command;
        }
    }
}
