using DataPlatform.Shared.Public.Messaging;

namespace Workflow
{
    public interface IPublishMessages
    {
        void Publish(IPublishableMessage message);
    }
}