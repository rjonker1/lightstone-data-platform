using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using EasyNetQ.AutoSubscribe;

namespace Workflow.BuildingBlocks
{
    internal class SyncDispatcher
    {
        private readonly List<ConsumerRegistration> consumers;
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public SyncDispatcher(List<ConsumerRegistration> consumers)
        {
            this.consumers = consumers;
        }

        private IEnumerable<IConsume<TMessage>> CreateConsumers<TMessage>() where TMessage : class
        {
            Type requestedMessageType = typeof (TMessage);

            return consumers
                .Where(c => c.MessageType == requestedMessageType)
                .Select(match => CreateConsumer<TMessage>(match, requestedMessageType))
                .ToList();
        }

        private IConsume<TMessage> CreateConsumer<TMessage>(ConsumerRegistration match, Type requestedMessageType)
            where TMessage : class
        {
            var consumer = match.CreateConsumer() as IConsume<TMessage>;

            if (consumer != null)
                return consumer;

            string failureMessage =
                string.Format(
                    "Failed to create consumer for message {0}. The supposed consumer is {1}. Moving to next consumer is available",
                    requestedMessageType, match.ConsumerType);

            log.ErrorFormat(failureMessage);

            throw new Exception(failureMessage);
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
            var ableConsumers = CreateConsumers<TMessage>().ToList();

            ableConsumers.ForEach(c => ExecuteConsumer(message, c));
        }
    }
}