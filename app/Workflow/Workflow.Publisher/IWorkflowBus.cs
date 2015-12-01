using System;
using System.Threading.Tasks;
using DataPlatform.Shared.Messaging;

namespace Workflow.Publisher
{
    public interface IWorkflowBus
    {
        void Publish(IPublishableMessage message);
        Task PublishAsync(IPublishableMessage message);
        void Subscribe<TMessage>(Action<IPublishableMessage> dispatch);
    }
}