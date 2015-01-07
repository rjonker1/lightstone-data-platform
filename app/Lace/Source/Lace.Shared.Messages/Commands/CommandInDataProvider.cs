using System;
namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class CommandInDataProvider
    {
        public CommandDto Command { get; private set; }

        public CommandInDataProvider(CommandDto command)
        {
            Command = command;
        }

        public CommandInDataProvider()
        {
        }
    }
}
