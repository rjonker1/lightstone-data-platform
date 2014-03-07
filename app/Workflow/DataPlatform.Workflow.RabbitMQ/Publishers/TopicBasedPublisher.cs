using DataPlatform.Shared.Public.Messaging;
using EasyNetQ;

namespace DataPlatform.Workflow.RabbitMQ.Publishers
{
    internal class TopicBasedPublisher : IRabbitMQPublisher
    {
        private readonly IBus bus;
        private readonly IRabbitMQPublisher nextPublisher;

        public TopicBasedPublisher(IBus bus, IRabbitMQPublisher nextPublisher)
        {
            this.bus = bus;
            this.nextPublisher = nextPublisher;
        }

        public void Publish(IPublishableMessage message)
        {
            if(!(message is ITopicPublishableMessage))
            {
                nextPublisher.Publish(message);
                return;
            }

            var messageToPublish = message as ITopicPublishableMessage;

            bus.Publish(messageToPublish, messageToPublish.Topic.Topic);
        }
    }
}