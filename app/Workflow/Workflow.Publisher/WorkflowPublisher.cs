using System.Threading.Tasks;
using DataPlatform.Shared.Messaging;
using EasyNetQ;

namespace Workflow.Publisher
{
    public interface IWorkflowPublisher
    {
        void Publish(IPublishableMessage message);
        Task PublishAsync(IPublishableMessage message);
    }

    public class WorkflowPublisher : IWorkflowPublisher
    {
        private readonly IBus _bus;

        public WorkflowPublisher(IBus bus)
        {
            _bus = bus;
        }
        public void Publish(IPublishableMessage message)
        {
            _bus.Publish(message);
        }

        public Task PublishAsync(IPublishableMessage message)
        {
            return _bus.PublishAsync(message);
        }
    }
}