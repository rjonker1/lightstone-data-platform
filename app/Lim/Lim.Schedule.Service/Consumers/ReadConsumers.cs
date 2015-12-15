using System;
using System.Collections.Generic;
using Castle.Windsor;
using EasyNetQ;
using Lim.Domain.Events;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Receiver.Handlers;
using Toolbox.LightstoneAuto.Consumers.Read;
using Toolbox.LightstoneAuto.Domain.Events;
using Toolbox.LIVE.Domain.Events;
using Toolbox.LIVE.Infrastructure.Consumers.Read;

namespace Lim.Schedule.Service.Consumers
{
    public class ReadConsumers<T>
    {
        public static ReadConsumers<T> New(IMessage<T> message, IWindsorContainer container)
        {
            return new ReadConsumers<T>(message, container);
        }

        private ReadConsumers(IMessage<T> message, IWindsorContainer container)
        {
            Action<IWindsorContainer, IMessage<T>> consumer;
            if (_consumers.TryGetValue(typeof (T), out consumer))
                consumer(container, message);
        }

        private readonly Dictionary<Type, Action<IWindsorContainer, IMessage<T>>> _consumers = new Dictionary
            <Type, Action<IWindsorContainer, IMessage<T>>>
        {
            {
                typeof (PackageConfigurationMessage),
                (container, message) => container.Resolve<AlwaysOnConfigurationConsumer>().Consume((IMessage<PackageConfigurationMessage>) message)
            },
            {
                typeof (ExecutedPackageSent),
                (container, message) => container.Resolve<ExecutedPackageSentConsumer>().Consume((IMessage<ExecutedPackageSent>) message)
            },
            {
                typeof (PackageReceived),
                (container, message) => container.Resolve<AlwaysOnConfigurationConsumer>().Consume((IMessage<PackageReceived>) message)
            },

            {
                typeof (DatabaseExtractCreated),
                (container, message) => container.Resolve<DatabaseExtractEventConsumer>().Consume((IMessage<DatabaseExtractCreated>) message)
            },
            {
                typeof (DatabaseExtractModified),
                (container, message) => container.Resolve<DatabaseExtractEventConsumer>().Consume((IMessage<DatabaseExtractModified>) message)
            },
            {
                typeof (DatabaseExtractDeActivated),
                (container, message) => container.Resolve<DatabaseExtractEventConsumer>().Consume((IMessage<DatabaseExtractDeActivated>) message)
            },

            {
                typeof (DatabaseViewLoaded),
                (container, message) => container.Resolve<DatabaseViewEventConsumer>().Consume((IMessage<DatabaseViewLoaded>) message)
            },
            {
                typeof (DatabaseViewModified),
                (container, message) => container.Resolve<DatabaseViewEventConsumer>().Consume((IMessage<DatabaseViewModified>) message)
            }
        };
    }
}