using System;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Shared;

namespace Lace.Test.Helper.Builders.Buses
{
    public class WorkflowBusBuilder
    {
        public static ISendWorkflowCommand ForWorkflowBus(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return new SendWorkflowCommands(bus,requestId);
        }
    }
}
