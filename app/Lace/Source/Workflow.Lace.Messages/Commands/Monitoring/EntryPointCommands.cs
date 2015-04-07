using System;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Messages.Core;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
    public class EntryPointReceivingRequest : DataProviderCommand
    {
        public EntryPointReceivingRequest(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    public class EntryPointProcessedAndReturningRequest : DataProviderCommand
    {
        public EntryPointProcessedAndReturningRequest(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }
}
