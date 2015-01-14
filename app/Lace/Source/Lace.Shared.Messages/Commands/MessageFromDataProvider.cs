using System;
namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderCommandEnvelope
    {
        public CommandDto Command { get; private set; }

        public DataProviderCommandEnvelope(CommandDto command)
        {
            Command = command;
        }

        public DataProviderCommandEnvelope()
        {
        }
    }
}
