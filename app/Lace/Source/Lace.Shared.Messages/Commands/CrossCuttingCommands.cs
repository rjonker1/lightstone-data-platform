using System;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderMonitoringCommand
    {
        public CommandDto Command { get; private set; }

        public DataProviderMonitoringCommand(CommandDto command)
        {
            Command = command;
        }

        public DataProviderMonitoringCommand()
        {
        }
    }

    [Serializable]
    public class ThrowError : DataProviderCommand
    {
        public ThrowError(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }
}
