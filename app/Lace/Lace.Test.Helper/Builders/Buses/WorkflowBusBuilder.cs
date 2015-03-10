using System;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Shared;

namespace Lace.Test.Helper.Builders.Buses
{
    public class WorkflowBusBuilder
    {
        public static ISendWorkflowCommandsToBus ForIvid(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return new SendWorkflowCommands(bus,requestId);
        }
    }

  
}
