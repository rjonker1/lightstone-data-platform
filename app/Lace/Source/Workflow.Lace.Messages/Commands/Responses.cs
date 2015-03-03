using System;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Commands
{
    public class ReceiveResponseCommand : Command
    {
        public ReceiveResponseCommand(Guid id, DataProviderCommandSource dataProvider, object payload, DateTime date)
            : base(id, dataProvider, payload, date)
        {
            
        }
    }
}
