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
        public ReadConsumers(IMessage<T> message, IWindsorContainer container)
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
                typeof (DataSetExportCreated),
                (container, message) => container.Resolve<DataSetExportEventConsumer>().Consume((IMessage<DataSetExportCreated>) message)
            },
            {
                typeof (DataSetExportModified),
                (container, message) => container.Resolve<DataSetExportEventConsumer>().Consume((IMessage<DataSetExportModified>) message)
            },
            {
                typeof (DataSetExportDeActivated),
                (container, message) => container.Resolve<DataSetExportEventConsumer>().Consume((IMessage<DataSetExportDeActivated>) message)
            },

            {
                typeof (ViewImportCreated),
                (container, message) => container.Resolve<ViewImportEventConsumer>().Consume((IMessage<ViewImportCreated>) message)
            },
            {
                typeof (ViewImportModified),
                (container, message) => container.Resolve<ViewImportEventConsumer>().Consume((IMessage<ViewImportModified>) message)
            },
            {
                typeof (ViewImportReloaded),
                (container, message) => container.Resolve<ViewImportEventConsumer>().Consume((IMessage<ViewImportReloaded>) message)
            },
            {
                typeof (ViewImportDeActivated),
                (container, message) => container.Resolve<ViewImportEventConsumer>().Consume((IMessage<ViewImportDeActivated>) message)
            },
        };
    }
}