using System;
using System.Collections.Generic;
using Castle.Windsor;
using EasyNetQ;
using Lim.Domain.Events;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Receiver.Handlers;
using Toolbox.LIVE.Domain.Events;
using Toolbox.LIVE.Infrastructure.Consumers.Read;

namespace Lim.Schedule.Service.Consumers
{
    public class ReadConsumers<T>
    {
        public ReadConsumers(IMessage<T> message, IWindsorContainer container)
        {
            Action<IWindsorContainer, IMessage<T>> consumer;
            if (_consumers.TryGetValue(typeof(T), out consumer))
                consumer(container, message);
        }

        private readonly Dictionary<Type, Action<IWindsorContainer, IMessage<T>>> _consumers = new Dictionary<Type, Action<IWindsorContainer, IMessage<T>>>
        {
            {typeof(PackageConfigurationMessage), (container,message) =>  container.Resolve<AlwaysOnConfigurationConsumer>().Consume((IMessage<PackageConfigurationMessage>)message)},
            {typeof(ExecutedPackageSent), (container, message) => container.Resolve<ExecutedPackageSentConsumer>().Consume((IMessage<ExecutedPackageSent>)message)},
            {typeof(PackageReceived), (container, message) => container.Resolve<AlwaysOnConfigurationConsumer>().Consume((IMessage<PackageReceived>)message)}
        };
    }
}