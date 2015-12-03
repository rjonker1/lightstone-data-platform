using Castle.Windsor;
using DataPlatform.Shared.Enums;
using Shared.Messages;
//using Workflow.BuildingBlocks;
using Workflow.Publisher;
using Xunit.Extensions;

namespace Shared.Unit.Tests
{
    public class when_publishing_log_message : Specification
    {
        private readonly IWorkflowBus _workflowBus = new WorkflowBus(BusBuilder.CreateBus());
        //private readonly IWorkflowBus _workflowBus = new WorkflowAdvancedBus(BusFactory.CreateAdvancedBus(new QueueDefinition ()), new WindsorContainer());
        public override void Observe()
        {

        }

        [Observation]
        public void should()
        {
            _workflowBus.Publish(new LogMessage("Test", LogLevel.Error, SystemName.Shared));
        }
    }
}
