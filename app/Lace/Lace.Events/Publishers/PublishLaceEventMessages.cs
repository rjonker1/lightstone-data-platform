using EasyNetQ;
using Workflow;
using Workflow.RabbitMQ;

namespace Lace.Events.Publishers
{
    public class PublishLaceEventMessages
    {
        private readonly IPublishMessages _publishMessages;

        public IPublishMessages PublishMessages
        {
            get
            {
                return _publishMessages;
            }
        }

        public PublishLaceEventMessages(IBus bus)
        {
            _publishMessages = new Publisher(bus);
        }
    }
}
