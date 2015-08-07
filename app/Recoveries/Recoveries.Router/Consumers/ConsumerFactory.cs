using Castle.Windsor;
using EasyNetQ;
using Recoveries.ErrorQueues.Messages;

namespace Recoveries.Router.Consumers
{
    public class ConsumerFactory<T>
    {
        public ConsumerFactory(IMessage<T> message, IWindsorContainer container)
        {
            if(message is IMessage<RetryErrorsOnAllQueuesMessage>)
                container.Resolve<RetryErrorsOnAllQueuesConsumer>().Consume((IMessage<RetryErrorsOnAllQueuesMessage>)message);
            if (message is IMessage<RetryErrorsOnAQueueMessage>)
                container.Resolve<RetryErrorsOnAQueuesConsumer>().Consume((IMessage<RetryErrorsOnAQueueMessage>)message);
        }
    }
}
