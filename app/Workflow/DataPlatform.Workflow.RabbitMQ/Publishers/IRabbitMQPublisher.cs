using DataPlatform.Shared.Public.Messaging;

namespace DataPlatform.Workflow.RabbitMQ.Publishers
{
    internal interface IRabbitMQPublisher
    {
        void Publish(IPublishableMessage message);
    }
}