using System;
using System.Threading.Tasks;
using DataPlatform.Shared.Messaging;
using EasyNetQ;

namespace Workflow.Publisher
{
    public sealed class WorkflowBus : IWorkflowBus
    {
        private readonly IBus _bus;

        public WorkflowBus(IBus bus)
        {
            _bus = bus;
        }

        public void Publish(IPublishableMessage message)
        {
            _bus.Publish(message);
        }

        public Task PublishAsync(IPublishableMessage message)
        {
            return _bus.PublishAsync(message);
        }

        public void Subscribe<TMessage>(Action<IPublishableMessage> dispatch)
        {
            _bus.Subscribe("WorkflowBus", dispatch);
        }
    }
}