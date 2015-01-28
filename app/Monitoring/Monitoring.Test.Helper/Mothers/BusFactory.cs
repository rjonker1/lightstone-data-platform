using System;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Publisher;
using Lace.Shared.Monitoring.Messages.Shared;
using NServiceBus;
using NServiceBus.Features;

namespace Monitoring.Test.Helper.Mothers
{
    public class BusBuilder
    {
        public static ISendCommandsToBus ForIvidCommands(Guid aggregateId)
        {
            var bus = BusFactory.NServiceRabbitMqWriteBus();
            return new SendIvidCommands(bus, aggregateId, (int) ExecutionOrder.First);
        }

        public static ISendCommandsToBus ForAudatexCommands(Guid aggregateId)
        {
            var bus = BusFactory.NServiceRabbitMqWriteBus();
            return new SendAudatexCommands(bus, aggregateId, (int) ExecutionOrder.Sixth);
        }

        public static CommandPublisher ForMonitoringReadMessages(Guid aggregateId)
        {
            var bus = BusFactory.NServiceRabbitMqReadBus();
            return new CommandPublisher(bus);
        }

        public static ISendCommandsToBus ForLightstoneCommands(Guid aggregateId)
        {
            var bus = BusFactory.NServiceRabbitMqReadBus();
            return new SendLightstoneCommands(bus, aggregateId, (int) ExecutionOrder.Second);
        }

        public static ISendCommandsToBus ForIvidTitleHolderCommands(Guid aggregateId)
        {
            var bus = BusFactory.NServiceRabbitMqReadBus();
            return new SendIvidTitleHolderCommands(bus, aggregateId, (int) ExecutionOrder.Third);
        }

        public static ISendCommandsToBus ForRgtCommands(Guid aggregateId)
        {
            var bus = BusFactory.NServiceRabbitMqReadBus();
            return new SendRgtCommands(bus, aggregateId, (int) ExecutionOrder.Fifth);
        }

        public static ISendCommandsToBus ForRgtVinCommands(Guid aggregateId)
        {
            var bus = BusFactory.NServiceRabbitMqReadBus();
            return new SendRgtVinCommands(bus, aggregateId, (int) ExecutionOrder.Fourth);
        }

        public static ISendCommandsToBus ForEntryPoint(Guid aggreagateId)
        {
            var bus = BusFactory.NServiceRabbitMqReadBus();
            return new SendEntryPointCommands(bus, aggreagateId, (int) ExecutionOrder.First);
        }
    }

    public class BusFactory
    {
        public static IBus NServiceRabbitMqWriteBus()
        {
            var configuration = new BusConfiguration();
            configuration.UseTransport<RabbitMQTransport>();
            configuration.DisableFeature<TimeoutManager>();
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.EndpointName("DataPlatform.Monitoring.Host");
            configuration.Conventions()
                .DefiningCommandsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith("Lace.Shared.Monitoring.Messages.Commands"))
                .DefiningEventsAs(
                    c => (c.Namespace != null && c.Namespace.StartsWith("DataPlatform.Shared.Messaging.Events") || (c.Namespace != null && c.Namespace.StartsWith("Lace.Shared.Monitoring.Messages.Events"))));
            var bus = Bus.Create(configuration);
            return bus;
        }

        public static IBus NServiceRabbitMqReadBus()
        {
            var configuration = new BusConfiguration();
            configuration.UseTransport<RabbitMQTransport>();
            configuration.DisableFeature<TimeoutManager>();
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.EndpointName("DataPlatform.Monitoring.DenormalizerHost");
            configuration.Conventions()
                .DefiningCommandsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith("Lace.Shared.Monitoring.Messages.Commands"))
                .DefiningEventsAs(
                     c => (c.Namespace != null && c.Namespace.StartsWith("DataPlatform.Shared.Messaging.Events") || (c.Namespace != null && c.Namespace.StartsWith("Lace.Shared.Monitoring.Messages.Events"))));
            var bus = Bus.Create(configuration);
            return bus;
        }
    }
}
