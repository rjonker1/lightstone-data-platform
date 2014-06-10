using System.Threading.Tasks;
using Castle.Windsor;
using Common.Logging;
using EasyNetQ.AutoSubscribe;

namespace Workflow.BuildingBlocks.Dispatcher
{
    public class WindsorMessageDispatcher : IAutoSubscriberMessageDispatcher
    {
        private readonly IWindsorContainer container;
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public WindsorMessageDispatcher(IWindsorContainer container)
        {
            this.container = container;
        }

        public void Dispatch<TMessage, TConsumer>(TMessage message)
            where TMessage : class
            where TConsumer : IConsume<TMessage>
        {
            log.InfoFormat("Received message of type {0}", message.GetType());

            var consumer = container.Resolve<TConsumer>();
            try
            {
                log.InfoFormat("Consuming message of type {0}", message.GetType());
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
            log.InfoFormat("Received message of type {0} as async", message.GetType());
            var consumer = container.Resolve<TConsumer>();
            return consumer.Consume(message).ContinueWith(t => container.Release(consumer));
        }
    }
}