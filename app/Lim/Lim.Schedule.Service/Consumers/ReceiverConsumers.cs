using Castle.Windsor;
using EasyNetQ;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Receiver.Handlers;

namespace Lim.Schedule.Service.Consumers
{
    public class ReceiverConsumers<T>
    {
        public ReceiverConsumers(IMessage<T> message, IWindsorContainer container)
        {
            if (message is IMessage<PackageConfigurationMessage>)
                container.Resolve<AlwaysOnConfigurationConsumer>().Consume((IMessage<PackageConfigurationMessage>)message);
        }
    }
}