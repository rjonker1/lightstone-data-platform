using System.Threading.Tasks;
using Castle.Windsor;
using EasyNetQ.AutoSubscribe;

namespace Workflow.BuildingBlocks.Dispatcher
{
    public class WindsorMessageDispatcher : IAutoSubscriberMessageDispatcher
    {
        private readonly IWindsorContainer container;

        public WindsorMessageDispatcher(IWindsorContainer container)
        {
            this.container = container;
        }

        public void Dispatch<TMessage, TConsumer>(TMessage message)
            where TMessage : class
            where TConsumer : IConsume<TMessage>
        {
            var consumer = container.Resolve<TConsumer>();
            try
            {
                consumer.Consume(message);
            }
            finally
            {
                container.Release(consumer);
            }
        }

        public Task DispatchAsync<TMessage, TConsumer>(TMessage message)
            where TMessage : class
            where TConsumer : IConsumeAsync<TMessage>
        {
            var consumer = container.Resolve<TConsumer>();
            return consumer.Consume(message).ContinueWith(t => container.Release(consumer));
        }
    }
}