using System;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Commands
{
    public class ReceiveRequestCommand : Command
    {
        public ReceiveRequestCommand(Guid id, DataProviderCommandSource dataProvider, object payload, DateTime date)
            : base(id, dataProvider, payload, date)
        {
            
        }
    }
}
