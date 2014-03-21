using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Logging;
using EasyNetQ.AutoSubscribe;

namespace Workflow.BuildingBlocks
{
    public class NoMagicAutoDispatcher : IAutoSubscriberMessageDispatcher
    {
        private readonly List<ConsumerRegistration> consumers;
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public NoMagicAutoDispatcher(List<ConsumerRegistration> consumers)
        {
            this.consumers = consumers;

            consumers.ForEach(c => log.InfoFormat("Registering consumer {0} -> {1}", c.ConsumerType, c.MessageType));
        }

        public void Dispatch<TMessage, TConsumer>(TMessage message) where TMessage : class
            where TConsumer : IConsume<TMessage>
        {
            var dispatcher = new SyncDispatcher(consumers);
            dispatcher.Dispatch(message);

        }

        public Task DispatchAsync<TMessage, TConsumer>(TMessage message) where TMessage : class
            where TConsumer : IConsumeAsync<TMessage>
        {
            throw new NotImplementedException("Async dispatch not yet handled");
        }
    }
}