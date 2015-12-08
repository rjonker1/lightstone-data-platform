using System.Threading;
using DataPlatform.Shared.Enums;
using Shared.Logging;
using Shared.Messages;
using Workflow.BuildingBlocks.Builders;
using Workflow.Publisher;
using Xunit.Extensions;

namespace Shared.Unit.Tests
{
    public class when_publishing_log_message : Specification
    {
        private readonly IWorkflowPublisher _workflowPublisher = new WorkflowPublisher(BusBuilder.CreateBus());
        //private readonly IWorkflowBus _workflowBus = new WorkflowAdvancedBus(BusFactory.CreateAdvancedBus(new QueueDefinition ()), new WindsorContainer());
        public override void Observe()
        {

        }

        [Observation]
        public void should_log_by_WorkflowPublisher()
        {
            _workflowPublisher.Publish(new LogMessage("", "Test", LogLevel.Error, SystemName.Shared));
        }

        [Observation]
        public void should_log_by_extension_method()
        {
            //this.Error(() => "Test", SystemName.Shared);
            this.Error(() => "Test");
            //Thread.Sleep(3000);
        }

        [Observation]
        public void should_log_by_DataPlatformLogger()
        {
            new DataPlatformLogger(_workflowPublisher).Error(GetType(), "Test");
            Thread.Sleep(3000);
        }
    }
}
