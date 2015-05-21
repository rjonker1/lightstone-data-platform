using Castle.Windsor;
using EasyNetQ;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Sender.Handlers;

namespace Lim.Schedule.Service.Consumers
{
    public class SenderConsumers<T>
    {
        public SenderConsumers(IMessage<T> message, IWindsorContainer container)
        {
            if (message is IMessage<PackageResponseMessage>)
                container.Resolve<ResponseFromPackageConsumer>().Consume((IMessage<PackageResponseMessage>)message);
        }
    }
}