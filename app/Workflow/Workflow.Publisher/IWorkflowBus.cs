using System;
using DataPlatform.Shared.Messaging;

namespace Workflow.Publisher
{
    public interface IWorkflowBus
    {
        void Publish(IPublishableMessage message);
        void Subscribe<TMessage>(Action<IPublishableMessage> dispatch);
    }
}