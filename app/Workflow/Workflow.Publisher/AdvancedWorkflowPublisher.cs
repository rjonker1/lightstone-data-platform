using System.Threading.Tasks;
using DataPlatform.Shared.Messaging;
using EasyNetQ;
using EasyNetQ.Topology;
using Workflow.BuildingBlocks;
using Workflow.BuildingBlocks.Configurations;

namespace Workflow.Publisher
{
    public class AdvancedWorkflowPublisher : IWorkflowPublisher
    {
        private readonly IAdvancedBus _bus;
        private readonly IDefineQueue _queue;

        public AdvancedWorkflowPublisher(IAdvancedBus bus)
        {
            _bus = bus;
            _queue = new QueueDefinition();
        }
        public void Publish(IPublishableMessage message)
        {
            _bus.Publish(new Exchange(_queue.ExchangeName), "", true, false, new Message<IPublishableMessage>(message));
        }

        public Task PublishAsync(IPublishableMessage message)
        {
            return _bus.PublishAsync(new Exchange(_queue.ExchangeName), "", true, false, new Message<IPublishableMessage>(message));
        }
    }
}