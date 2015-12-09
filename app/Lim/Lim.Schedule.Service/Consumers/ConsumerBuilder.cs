using Castle.Windsor;
using EasyNetQ;
using EasyNetQ.Topology;
using Lim.Domain.Events;
using Lim.Domain.Messaging.Messages;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;
using Toolbox.LightstoneAuto.Domain.Commands.View;
using Toolbox.LightstoneAuto.Domain.Events;
using Toolbox.LIVE.Domain.Events;
using Toolbox.LIVE.Shared.Commands;

namespace Lim.Schedule.Service.Consumers
{
    public static class ConsumerBuilder
    {
        public static IAdvancedBus BindWriteQueue(this IAdvancedBus bus, IWindsorContainer container)
        {
            var senderQueue = bus.QueueDeclare("DataPlatform.Integration.Sender");
            var senderExchange = bus.ExchangeDeclare("DataPlatform.Integration.Sender", ExchangeType.Fanout);
            bus.Bind(senderExchange, senderQueue, string.Empty);
            return bus.AddWriteConsumers(senderQueue, container);
        }

        public static IAdvancedBus BindReadQueue(this IAdvancedBus bus, IWindsorContainer container)
        {
            var receiverQueue = bus.QueueDeclare("DataPlatform.Integration.Receiver");
            var receiverExchange = bus.ExchangeDeclare("DataPlatform.Integration.Receiver", ExchangeType.Fanout);
            bus.Bind(receiverExchange, receiverQueue, string.Empty);
            return bus.AddReadConsumers(receiverQueue, container);
        }


        private static IAdvancedBus AddReadConsumers(this IAdvancedBus bus, IQueue queue, IWindsorContainer container)
        {
            bus.Consume(queue, q => q
                .Add<PackageConfigurationMessage>((message, info) => new ReadConsumers<PackageConfigurationMessage>(message, container))
                .Add<ExecutedPackageSent>((message, info) => new ReadConsumers<ExecutedPackageSent>(message, container))
                .Add<PackageReceived>((message, info) => new ReadConsumers<PackageReceived>(message, container))

                .Add<DataSetExportCreated>((message, info) => new ReadConsumers<DataSetExportCreated>(message, container))
                .Add<DataSetExportModified>((message, info) => new ReadConsumers<DataSetExportModified>(message, container))
                .Add<DataSetExportDeActivated>((message, info) => new ReadConsumers<DataSetExportDeActivated>(message, container))

                .Add<ViewImportCreated>((message, info) => new ReadConsumers<ViewImportCreated>(message, container))
                .Add<ViewImportModified>((message, info) => new ReadConsumers<ViewImportModified>(message, container))
                .Add<ViewImportReloaded>((message, info) => new ReadConsumers<ViewImportReloaded>(message, container))
                .Add<ViewImportDeActivated>((message, info) => new ReadConsumers<ViewImportDeActivated>(message, container)));
            return bus;
        }

        private static IAdvancedBus AddWriteConsumers(this IAdvancedBus bus, IQueue queue, IWindsorContainer container)
        {
            bus.Consume(queue, q => q
                .Add<PackageResponseMessage>((message, info) => new WriteConsumers<PackageResponseMessage>(message, container))
                .Add<SendExecutedPackage>((message, info) => new WriteConsumers<SendExecutedPackage>(message, container))

                .Add<CreateDataSetExport>((message, info) => new WriteConsumers<CreateDataSetExport>(message, container))
                .Add<ModifyDataSetExport>((message, info) => new WriteConsumers<ModifyDataSetExport>(message, container))
                .Add<DeActivateDataSetExport>((message, info) => new WriteConsumers<DeActivateDataSetExport>(message, container))

                .Add<CreateViewImport>((message, info) => new WriteConsumers<CreateViewImport>(message, container))
                .Add<ModifyViewImport>((message, info) => new WriteConsumers<ModifyViewImport>(message, container))
                .Add<DeActivateViewImport>((message, info) => new WriteConsumers<DeActivateViewImport>(message, container))
                .Add<ReloadViewImport>((message, info) => new WriteConsumers<ReloadViewImport>(message, container)));

            return bus;
        }
    }
}
