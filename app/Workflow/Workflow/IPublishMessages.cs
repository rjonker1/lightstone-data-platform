using DataPlatform.Shared.Messaging;

namespace Workflow
{
    public interface IPublishMessages
    {
        void Publish<TMessage>(TMessage message) where TMessage : class, IPublishableMessage;
    }
}