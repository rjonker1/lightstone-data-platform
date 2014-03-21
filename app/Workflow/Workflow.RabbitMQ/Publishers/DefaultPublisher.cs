using Common.Logging;
using DataPlatform.Shared.Public.Messaging;
using EasyNetQ;

namespace Workflow.RabbitMQ.Publishers
{
    internal class DefaultPublisher : IRabbitMQPublisher
    {
        private readonly IBus bus;
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public DefaultPublisher(IBus bus)
        {
            this.bus = bus;
        }

        public void Publish(IPublishableMessage message)
        {
            log.InfoFormat("Publishing message {0}", message.GetType());
            bus.Publish(message);
        }

        public bool CanPublishMessage(IPublishableMessage message)
        {
            return true;
        }
    }
}