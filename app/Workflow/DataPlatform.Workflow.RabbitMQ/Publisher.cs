using DataPlatform.Shared.Public.Messaging;
using DataPlatform.Workflow.RabbitMQ.Publishers;
using EasyNetQ;

namespace DataPlatform.Workflow.RabbitMQ
{
    public class Publisher : IPublishMessages
    {
        private readonly IRabbitMQPublisher publisher;
        private readonly 

        public Publisher(IBus bus)
        {
            publisher = new TopicBasedPublisher(bus, new DefaultPublisher(bus));
        }

        public void Publish(IPublishableMessage message)
        {
            publisher.Publish(message);
        }
    }
}