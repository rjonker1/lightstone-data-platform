using System;
using Common.Logging;
using DataPlatform.Shared.Public.Messaging;
using EasyNetQ;

namespace Workflow.RabbitMQ.Publishers
{
    internal class TopicBasedPublisher : IRabbitMQPublisher
    {
        private readonly IBus bus;
        private readonly ILog log = LogManager.GetCurrentClassLogger();
        private bool disposed;

        public TopicBasedPublisher(IBus bus)
        {
            this.bus = bus;
        }

        ~TopicBasedPublisher()
        {
            Dispose(false);
        }

        public void Publish<TMessage>(TMessage message) where TMessage : class, IPublishableMessage
        {
            if (!CanPublishMessage(message))
                return;

            log.InfoFormat("Publishing message {0} in topic based publisher", message.GetType());

            var messageToPublish = message as ITopicPublishableMessage;

            bus.Publish(messageToPublish, messageToPublish.Topic.Topic);
        }

        public bool CanPublishMessage<TMessage>(TMessage message) where TMessage : class, IPublishableMessage
        {
            return message is ITopicPublishableMessage;
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
                    if (bus != null)
                    {
                        bus.Dispose();
                    }
                }
            }
            disposed = true;
        }
    }
}