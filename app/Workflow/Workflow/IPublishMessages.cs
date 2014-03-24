using DataPlatform.Shared.Public.Messaging;

namespace Workflow
{
    public interface IPublishMessages
    {
        void Publish<TMessage>(TMessage message) where TMessage : class, IPublishableMessage;
    }
}