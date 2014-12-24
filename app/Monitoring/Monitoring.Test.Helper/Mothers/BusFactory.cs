using System;
using Lace.Shared.Monitoring.Messages.Shared;
using NServiceBus;
using NServiceBus.Features;

namespace Monitoring.Test.Helper.Mothers
{
    public class BusBuilder
    {
        public static ISendMonitoringMessages ForMonitoringWriteMessages(Guid aggregateId)
        {
            var bus = BusFactory.NServiceRabbitMqWriteBus();
            return new MonitoringMessageSender(bus, aggregateId);
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
                    c => c.Namespace != null && c.Namespace.StartsWith("Lace.Shared.Monitoring.Messages.Events"));
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
                    c => c.Namespace != null && c.Namespace.StartsWith("Lace.Shared.Monitoring.Messages.Events"));
            var bus = Bus.Create(configuration);
            return bus;
        }
    }
}
