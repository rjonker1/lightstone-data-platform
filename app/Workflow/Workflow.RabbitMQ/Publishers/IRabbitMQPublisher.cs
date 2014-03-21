using DataPlatform.Shared.Public.Messaging;

namespace Workflow.RabbitMQ.Publishers
{
    internal interface IRabbitMQPublisher
    {
        void Publish(IPublishableMessage message);
    }
}