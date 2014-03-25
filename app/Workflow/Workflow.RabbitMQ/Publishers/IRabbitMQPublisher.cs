using DataPlatform.Shared.Public.Messaging;

namespace Workflow.RabbitMQ.Publishers
{
    internal interface IRabbitMQPublisher
    {
        void Publish<TMessage>(TMessage message) where TMessage : class, IPublishableMessage;
        bool CanPublishMessage<TMessage>(TMessage message) where TMessage : class, IPublishableMessage;
    }
}