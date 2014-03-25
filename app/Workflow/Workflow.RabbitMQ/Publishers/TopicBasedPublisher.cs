using Common.Logging;
using DataPlatform.Shared.Public.Messaging;
using EasyNetQ;

namespace Workflow.RabbitMQ.Publishers
{
    internal class TopicBasedPublisher : IRabbitMQPublisher
    {
        private readonly IBus bus;
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public TopicBasedPublisher(IBus bus)
        {
            this.bus = bus;
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
    }
}