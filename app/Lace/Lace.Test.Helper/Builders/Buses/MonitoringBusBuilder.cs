using System;
using DataPlatform.Shared.ExceptionHandling;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using NServiceBus;
using NServiceBus.Features;

namespace Lace.Test.Helper.Builders.Buses
{
    public class MonitoringBusBuilder
    {
        public static ISendMonitoringCommandsToBus ForIvidCommands(Guid aggregateId)
        {
            var bus = BusFactory.MonitoringBus();
            return new SendIvidCommands(bus, aggregateId, (int) ExecutionOrder.First);
        }

        public static ISendMonitoringCommandsToBus ForAudatexCommands(Guid aggregateId)
        {
            var bus = BusFactory.MonitoringBus();
            return new SendAudatexCommands(bus, aggregateId, (int) ExecutionOrder.Sixth);
        }

        public static ISendMonitoringCommandsToBus ForLightstoneCommands(Guid aggregateId)
        {
            var bus = BusFactory.MonitoringBus();
            return new SendLightstoneCommands(bus, aggregateId, (int) ExecutionOrder.Second);
        }

        public static ISendMonitoringCommandsToBus ForIvidTitleHolderCommands(Guid aggregateId)
        {
            var bus = BusFactory.MonitoringBus();
            return new SendIvidTitleHolderCommands(bus, aggregateId, (int) ExecutionOrder.Third);
        }

        public static ISendMonitoringCommandsToBus ForRgtCommands(Guid aggregateId)
        {
            var bus = BusFactory.MonitoringBus();
            return new SendRgtCommands(bus, aggregateId, (int) ExecutionOrder.Fifth);
        }

        public static ISendMonitoringCommandsToBus ForRgtVinCommands(Guid aggregateId)
        {
            var bus = BusFactory.MonitoringBus();
            return new SendRgtVinCommands(bus, aggregateId, (int) ExecutionOrder.Fourth);
        }

        public static ISendMonitoringCommandsToBus ForSignioDriversLicenseCommands(Guid aggregateId)
        {
            var bus = BusFactory.MonitoringBus();
            return new SendSignioCommands(bus, aggregateId, (int)ExecutionOrder.Fourth);
        }

        public static ISendMonitoringCommandsToBus ForPCubedCommands(Guid aggregateId)
        {
            var bus = BusFactory.MonitoringBus();
            return new SendRgtVinCommands(bus, aggregateId, (int)ExecutionOrder.Fourth);
        }

        public static ISendMonitoringCommandsToBus ForLightstonePropertyCommands(Guid aggregateId)
        {
            var bus = BusFactory.MonitoringBus();
            return new SendLightstonePropertyCommands(bus, aggregateId, (int)ExecutionOrder.Fourth);
        }
    }

    public class BusFactory
    {
        public static IBus MonitoringBus()
        {

            var assembliesToScan =
                AllAssemblies.Matching("Lightstone.DataPlatform.Lace.Shared.Monitoring.Messages")
                    .And("NServiceBus.NHibernate")
                    .And("NServiceBus.Transports.RabbitMQ");
            return
                new DataPlatform.Shared.Messaging.RabbitMQ.BusFactory("Monitoring.Messages.Commands", assembliesToScan,
                    "DataPlatform.Monitoring.Host").CreateBusWithNHibernatePersistence();
        }

        public static IBus WorkflowBus()
        {
            var assembliesToScan =
                AllAssemblies.Matching("Lightstone.DataPlatform.Workflow.Lace.Messages")
                    .And("NServiceBus.NHibernate")
                    .And("NServiceBus.Transports.RabbitMQ");
            return
                new DataPlatform.Shared.Messaging.RabbitMQ.BusFactory("Workflow.Lace.Messages.Commands",
                    assembliesToScan,
                    "DataPlatform.DataProviders.Host.Write").CreateBusWithInMemoryPersistence();
        }
    }
}
