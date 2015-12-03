using System;
using System.Threading.Tasks;
using Castle.Windsor;
using DataPlatform.Shared.Messaging;
using EasyNetQ;
using EasyNetQ.Topology;
using Workflow.BuildingBlocks;

namespace Workflow.Publisher
{
    public sealed class WorkflowAdvancedBus : IWorkflowBus
    {
        private readonly IAdvancedBus _bus;
        private readonly IDefineQueue _queue;
        private readonly IWindsorContainer _container;

        public WorkflowAdvancedBus(IAdvancedBus bus, IWindsorContainer container)
        {
            _bus = bus;
            _queue = new QueueDefinition();
            _container = container;
        }

        public void Publish(IPublishableMessage message)
        {
            _bus.Publish(new Exchange(_queue.ExchangeName), "", true, false, new Message<IPublishableMessage>(message));
        }

        public Task PublishAsync(IPublishableMessage message)
        {
            return _bus.PublishAsync(new Exchange(_queue.ExchangeName), "", true, false, new Message<IPublishableMessage>(message));
        }

        public void Subscribe<TMessage>(Action<IPublishableMessage> dispatch)
        {
            var queue = _bus.QueueDeclare(typeof(TMessage).Name);
            //_bus.Bind(new Exchange(_queue.ExchangeName), queue, string.Empty);
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