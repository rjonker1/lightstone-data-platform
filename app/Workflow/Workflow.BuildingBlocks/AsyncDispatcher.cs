using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using EasyNetQ.AutoSubscribe;

namespace Workflow.BuildingBlocks
{
    internal class AsyncDispatcher
    {
        private readonly List<ConsumerRegistration> consumers;
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public AsyncDispatcher(List<ConsumerRegistration> consumers)
        {
            this.consumers = consumers;
        }

        private IEnumerable<IConsumeAsync<TMessage>> CreateConsumers<TMessage>() where TMessage : class
        {
            Type requestedMessageType = typeof (TMessage);

            return consumers
                .Where(c => c.MessageType == requestedMessageType)
                .Select(match => CreateConsumer<TMessage>(match, requestedMessageType))
                .ToList();
        }

        private IConsumeAsync<TMessage> CreateConsumer<TMessage>(ConsumerRegistration match, Type requestedMessageType)
            where TMessage : class
        {
            var consumer = match.CreateConsumer() as IConsumeAsync<TMessage>;

            if (consumer != null)
                return consumer;

            string failureMessage =
                string.Format(
                    "Failed to create consumer for message {0}. The supposed consumer is {1}. Moving to next consumer is available",
                    requestedMessageType, match.ConsumerType);

            log.ErrorFormat(failureMessage);

            throw new Exception(failureMessage);
        }

        private void ExecuteConsumer<TMessage>(TMessage message, IConsumeAsync<TMessage> consumer)
            where TMessage : class
        {
            if (consumer == null)
                return;

            try
            {
                consumer
                    .Consume(message)
                    .ContinueWith(c =>
                                  {
                                      if (consumer is IDisposable)
                                      {
                                          (consumer as IDisposable).Dispose();
                                      }
                                  });
            }
            catch (Exception e)
            {
                log.ErrorFormat("Consumption of the message type {0} by {1} failed because: {2}", message.GetType(),
                    consumer.GetType(), e.Message);
                throw;
            }
        }

        public void Dispatch<TMessage>(TMessage message) where TMessage : class
        {
            var ableConsumers = CreateConsumers<TMessage>().ToList();

            ableConsumers.ForEach(c => ExecuteConsumer(message, c));
        }
    }
}