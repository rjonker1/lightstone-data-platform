using System;
using System.Linq;
using Common.Logging;
using EasyNetQ.AutoSubscribe;
using Workflow.BuildingBlocks.Consumers;

namespace Workflow.BuildingBlocks.Dispatcher
{
    internal class SyncDispatcher
    {
        private readonly ConsumerRegistration consumers;
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public SyncDispatcher(ConsumerRegistration consumers)
        {
            this.consumers = consumers;
        }

        private void ExecuteConsumer<TMessage>(TMessage message, IConsume<TMessage> consumer) where TMessage : class
        {
            if (consumer == null)
                return;

            try
            {
                consumer.Consume(message);
            }
            catch (Exception e)
            {
                log.ErrorFormat("Consumption of the message type {0} by {1} failed because: {2}", message.GetType(),
                    consumer.GetType(), e.Message);
                throw;
            }
            finally
            {
                if (consumer is IDisposable)
                {
                    (consumer as IDisposable).Dispose();
                }


            }
        }

        public void Dispatch<TMessage>(TMessage message) where TMessage : class
        {
            var ableConsumers = consumers
                .GetConsumers<TMessage>()
                .ToList();

            ableConsumers.ForEach(c => ExecuteConsumer(message, c));
        }
    }
}