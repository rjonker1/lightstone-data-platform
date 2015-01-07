using System;
namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class MessageFromDataProvider
    {
        public CommandDto Command { get; private set; }

        public MessageFromDataProvider(CommandDto command)
        {
            Command = command;
        }

        public MessageFromDataProvider()
        {
        }
    }
}
