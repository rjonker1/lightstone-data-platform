using System;
using DataPlatform.Shared.Messaging;

namespace Workflow.Bus.Subscribers
{
    public interface IWorkflowSubscriber
    {
        void Subscribe<TMessage>(Action<IPublishableMessage> dispatch);
    }
}