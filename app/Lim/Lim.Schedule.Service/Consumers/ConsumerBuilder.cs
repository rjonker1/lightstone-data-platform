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
                .Add<PackageConfigurationMessage>((message, info) => ReadConsumers<PackageConfigurationMessage>.New(message, container))
                .Add<ExecutedPackageSent>((message, info) => ReadConsumers<ExecutedPackageSent>.New(message, container))
                .Add<PackageReceived>((message, info) => ReadConsumers<PackageReceived>.New(message, container))

                .Add<DatabaseExtractCreated>((message, info) => ReadConsumers<DatabaseExtractCreated>.New(message, container))
                .Add<DatabaseExtractModified>((message, info) => ReadConsumers<DatabaseExtractModified>.New(message, container))
                .Add<DatabaseExtractDeActivated>((message, info) => ReadConsumers<DatabaseExtractDeActivated>.New(message, container))

                .Add<DatabaseViewLoaded>((message, info) => ReadConsumers<DatabaseViewLoaded>.New(message, container))
                .Add<DatabaseViewModified>((message, info) => ReadConsumers<DatabaseViewModified>.New(message, container)));
            return bus;
        }

        private static IAdvancedBus AddWriteConsumers(this IAdvancedBus bus, IQueue queue, IWindsorContainer container)
        {
            bus.Consume(queue, q => q
                .Add<PackageResponseMessage>((message, info) => WriteConsumers<PackageResponseMessage>.New(message, container))
                .Add<SendExecutedPackage>((message, info) => WriteConsumers<SendExecutedPackage>.New(message, container))

                .Add<CreateDataExtract>((message, info) => WriteConsumers<CreateDataExtract>.New(message, container))
                .Add<ModifyDataExtract>((message, info) => WriteConsumers<ModifyDataExtract>.New(message, container))
                .Add<DeActivateDataExtract>((message, info) => WriteConsumers<DeActivateDataExtract>.New(message, container))

                .Add<LoadView>((message, info) => WriteConsumers<LoadView>.New(message, container))
                .Add<ModifyView>((message, info) => WriteConsumers<ModifyView>.New(message, container)));

            return bus;
        }
    }
}
