using System;
using Castle.Windsor;
using DataPlatform.Shared.Messaging;
using EasyNetQ;

namespace Workflow.Bus.Subscribers
{
    public sealed class AdvancedWorkflowSubscriber : IWorkflowSubscriber
    {
        private readonly IAdvancedBus _bus;
        private readonly IWindsorContainer _container;

        public AdvancedWorkflowSubscriber(IAdvancedBus bus, IWindsorContainer container)
        {
            _bus = bus;
            _container = container;
        }

        public void Subscribe<TMessage>(Action<IPublishableMessage> dispatch)
        {
            var queue = _bus.QueueDeclare(typeof(TMessage).Name);
            _bus.Consume(queue, x => x.Add<IPublishableMessage>((message, info) =>
            {
                var m = message.Body;
                var consumerType = typeof(IHandleMessages<>).MakeGenericType(m.GetType());
                var consumer = _container.Resolve(consumerType) as IHandleMessages;
                 consumer.Handle(m);
            }));
        }
    }
}