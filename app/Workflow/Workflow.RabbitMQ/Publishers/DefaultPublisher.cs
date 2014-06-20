using System;
using Common.Logging;
using DataPlatform.Shared.Messaging;
using EasyNetQ;

namespace Workflow.RabbitMQ.Publishers
{
    internal class DefaultPublisher : IRabbitMQPublisher
    {
        private readonly IBus bus;
        private readonly ILog log = LogManager.GetCurrentClassLogger();
        private bool disposed;

        public DefaultPublisher(IBus bus)
        {
            this.bus = bus;
        }

        public void Publish<TMessage>(TMessage message) where TMessage : class, IPublishableMessage
        {
            log.InfoFormat("Publishing message {0}", message.GetType());
            bus.Publish(message);
        }

        public bool CanPublishMessage<TMessage>(TMessage message) where TMessage : class, IPublishableMessage
        {
            return true;
        }

        ~DefaultPublisher()
        {
            Dispose(false);
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