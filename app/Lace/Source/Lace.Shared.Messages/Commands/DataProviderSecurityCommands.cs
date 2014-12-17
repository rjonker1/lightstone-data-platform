using System;
namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderHasSecurityCommand
    {
        public DataProviderCommandDto Command { get; private set; }

        public DataProviderHasSecurityCommand(DataProviderCommandDto command)
        {
            Command = command;
        }

        public DataProviderHasSecurityCommand()
        {
        }
    }
}
