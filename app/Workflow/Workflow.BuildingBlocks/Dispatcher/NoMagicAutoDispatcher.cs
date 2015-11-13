using System;
using System.Threading.Tasks;
using Common.Logging;
using EasyNetQ.AutoSubscribe;
using Workflow.BuildingBlocks.Consumers;

namespace Workflow.BuildingBlocks.Dispatcher
{
    public class NoMagicAutoDispatcher : IAutoSubscriberMessageDispatcher
    {
        private readonly ConsumerRegistration _consumers;
        private readonly ILog _log = LogManager.GetLogger<NoMagicAutoDispatcher>();

        public NoMagicAutoDispatcher(ConsumerRegistration consumers)
        {
            _consumers = consumers;
        }

        public void Dispatch<TMessage, TConsumer>(TMessage message) where TMessage : class
            where TConsumer : IConsume<TMessage>
        {
            var dispatcher = new SyncDispatcher(_consumers);
            dispatcher.Dispatch(message);

        }

        public Task DispatchAsync<TMessage, TConsumer>(TMessage message) where TMessage : class
            where TConsumer : IConsumeAsync<TMessage>
        {
            throw new NotImplementedException("Async dispatch not yet handled");
        }
    }
}