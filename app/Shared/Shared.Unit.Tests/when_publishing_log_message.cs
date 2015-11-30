using DataPlatform.Shared.Enums;
using Shared.Messages;
using Workflow.Publisher;
using Xunit.Extensions;

namespace Shared.Unit.Tests
{
    public class when_publishing_log_message : Specification
    {
        private readonly IWorkflowBus _workflowBus = new WorkflowBus(BusBuilder.CreateBus());
        public override void Observe()
        {

        }

        [Observation]
        public void should()
        {
            _workflowBus.Publish(new LogMessage("Test", LogLevel.Debug, SystemName.Shared));
        }
    }
}
