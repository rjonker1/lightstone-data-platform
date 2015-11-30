using System;
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

        public void Subscribe<TMessage>(Action<IPublishableMessage> dispatch)
        {
            _bus.Subscribe("WorkflowBus", dispatch);
        }
    }
}