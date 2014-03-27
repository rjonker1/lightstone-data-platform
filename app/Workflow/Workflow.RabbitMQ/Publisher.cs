using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Recovery;
using Common.Logging;
using DataPlatform.Shared.Public.Messaging;
using EasyNetQ;
using Workflow.RabbitMQ.Publishers;

namespace Workflow.RabbitMQ
{
    public class Publisher : IPublishMessages, IDisposable
    {
        private readonly ILog log = LogManager.GetCurrentClassLogger();
        private readonly RetryAgent agent;
        private readonly List<IRabbitMQPublisher> publishers;
        private bool disposed;

        public Publisher(IBus bus, IRetryStrategy retryStrategy)
        {
            agent = new RetryAgent(retryStrategy);
            publishers = new List<IRabbitMQPublisher>()
                         {
                             new TopicBasedPublisher(bus),
                             new DefaultPublisher(bus)
                         };
        }

        public Publisher(IBus bus) : this(bus, new DefaultRabbitMQRetryStrategy())
        {
        }

        ~Publisher()
        {
            Dispose(false);
        }

        public void Publish<TMessage>(TMessage message) where TMessage : class, IPublishableMessage
        {
            if (message == null)
            {
                log.WarnFormat("Received a NULL message. Can't publish a NULL message");
                throw new ArgumentNullException("message");
            }

            log.InfoFormat("Publishing {0} in RabbitMQ publisher", message.GetType());

            PublishWithRetry(message);
        }

        private void PublishWithRetry<TMessage>(TMessage message) where TMessage : class, IPublishableMessage
        {
            var results = agent
                .OnException(e => log.ErrorFormat("Failed to publish message {0} to RabbitMQ, because '{1}'", message.GetType(), e))
                .Execute(() => PublishMessage(message), () => true);

            if (!results.Succeeded)
                throw results.FirstFailure();
        }

        private void PublishMessage<TMessage>(TMessage message) where TMessage : class, IPublishableMessage
        {
            publishers
                .Where(p => p.CanPublishMessage(message))
                .ToList()
                .ForEach(p => p.Publish(message));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (publishers != null)
                        publishers.ForEach(p => p.Dispose());
                }
            }
            disposed = true;
        }
    }
}