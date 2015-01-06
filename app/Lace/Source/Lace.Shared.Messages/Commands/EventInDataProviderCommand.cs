using System;
namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class EventInDataProviderCommand
    {
        public CommandDto Command { get; private set; }

        public EventInDataProviderCommand(CommandDto command)
        {
            Command = command;
        }

        public EventInDataProviderCommand()
        {
        }
    }
}
