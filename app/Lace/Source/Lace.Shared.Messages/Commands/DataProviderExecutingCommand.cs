using System;
namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderExecutingCommand
    {
        public DataProviderCommandDto DataProviderCommand { get; private set; }

        public DataProviderExecutingCommand(DataProviderCommandDto command)
        {
            DataProviderCommand = command;
        }
    }
}
