using System;
using System.Collections.Generic;
using Castle.Windsor;
using EasyNetQ;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Sender.Handlers;
using Toolbox.LightstoneAuto.Consumers.Write;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;
using Toolbox.LightstoneAuto.Domain.Commands.View;
using Toolbox.LIVE.Infrastructure.Consumers.Write;
using Toolbox.LIVE.Shared.Commands;

namespace Lim.Schedule.Service.Consumers
{
    public class WriteConsumers<T>
    {
        public WriteConsumers(IMessage<T> message, IWindsorContainer container)
        {
           Action<IWindsorContainer,IMessage<T>> consumer;
           if (_consumers.TryGetValue(typeof(T), out consumer))
                consumer(container, message);
        }

        private readonly Dictionary<Type, Action<IWindsorContainer, IMessage<T>>> _consumers = new Dictionary<Type, Action<IWindsorContainer, IMessage<T>>>
        {
            {typeof(PackageResponseMessage), (container,message) =>  container.Resolve<ResponseFromPackageConsumer>().Consume((IMessage<PackageResponseMessage>)message)},
            {typeof(SendExecutedPackage), (container, message) => container.Resolve<SendExecutedPackageConsumer>().Consume((IMessage<SendExecutedPackage>)message)},

            {typeof(CreateDataSetExport), (container, message)=> container.Resolve<DataSetExportCommandConsumer>().Consume((IMessage<CreateDataSetExport>)message)},
            {typeof(ModifyDataSetExport), (container, message)=> container.Resolve<DataSetExportCommandConsumer>().Consume((IMessage<ModifyDataSetExport>)message)},
            {typeof(DeActivateDataSetExport), (container, message)=> container.Resolve<DataSetExportCommandConsumer>().Consume((IMessage<DeActivateDataSetExport>)message)},

            {typeof(CreateViewImport), (container, message)=> container.Resolve<ViewImportCommandConsumer>().Consume((IMessage<CreateViewImport>)message)},
            {typeof(ModifyViewImport), (container, message)=> container.Resolve<ViewImportCommandConsumer>().Consume((IMessage<ModifyViewImport>)message)},
            {typeof(DeActivateViewImport), (container, message)=> container.Resolve<ViewImportCommandConsumer>().Consume((IMessage<DeActivateViewImport>)message)},
            {typeof(ReloadViewImport), (container, message)=> container.Resolve<ViewImportCommandConsumer>().Consume((IMessage<ReloadViewImport>)message)}

        };
    }
}