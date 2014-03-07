using DataPlatform.Shared.Public.Messaging;
using EasyNetQ;

namespace DataPlatform.Workflow.RabbitMQ.Publishers
{
    internal class DefaultPublisher : IRabbitMQPublisher
    {
        private readonly IBus bus;

        public DefaultPublisher(IBus bus)
        {
            this.bus = bus;
        }

        public void Publish(IPublishableMessage message)
        {
            bus.Publish(message);
        }
    }
}