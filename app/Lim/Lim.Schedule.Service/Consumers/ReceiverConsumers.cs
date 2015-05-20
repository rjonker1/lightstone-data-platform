using Castle.Windsor;
using EasyNetQ;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Receiver.Consumers;

namespace Lim.Schedule.Service.Consumers
{
    public class ReceiverConsumers<T>
    {
        public ReceiverConsumers(IMessage<T> message, IWindsorContainer container)
        {
            if (message is IMessage<MappedPackageResponseSentMessage>)
                container.Resolve<PackageResponseReceiver>().Consume((IMessage<MappedPackageResponseSentMessage>)message);
        }
    }
}
