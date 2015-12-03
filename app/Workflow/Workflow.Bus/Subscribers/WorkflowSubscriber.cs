using System;
using DataPlatform.Shared.Messaging;
using EasyNetQ;

namespace Workflow.Bus.Subscribers
{
    public sealed class WorkflowSubscriber : IWorkflowSubscriber
    {
        private readonly IBus _bus;

        public WorkflowSubscriber(IBus bus)
        {
            _bus = bus;
        }

        public void Subscribe<TMessage>(Action<IPublishableMessage> dispatch)
        {
            _bus.Subscribe("WorkflowBus", dispatch);
        }
    }
}