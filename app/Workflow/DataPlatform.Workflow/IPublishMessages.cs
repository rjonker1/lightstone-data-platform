using DataPlatform.Shared.Public.Messaging;

namespace DataPlatform.Workflow
{
    public interface IPublishMessages
    {
        void Publish(IPublishableMessage message);
    }
}