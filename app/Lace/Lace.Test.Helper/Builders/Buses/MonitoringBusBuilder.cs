using System;
using DataPlatform.Shared.Enums;
using NServiceBus;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Shared;

namespace Lace.Test.Helper.Builders.Buses
{
    public class MonitoringBusBuilder
    {
        public static ISendCommandToBus ForIvidCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, (int)ExecutionOrder.First, DataProviderCommandSource.Ivid);
        }

        public static ISendCommandToBus ForAudatexCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, (int)ExecutionOrder.Sixth, DataProviderCommandSource.Audatex);
        }

        public static ISendCommandToBus ForLightstoneCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, (int)ExecutionOrder.Second, DataProviderCommandSource.LightstoneAuto);
        }

        public static ISendCommandToBus ForIvidTitleHolderCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, (int)ExecutionOrder.Third, DataProviderCommandSource.IvidTitleHolder);
        }

        public static ISendCommandToBus ForRgtCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, (int)ExecutionOrder.Fifth, DataProviderCommandSource.Rgt);
        }

        public static ISendCommandToBus ForRgtVinCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, (int)ExecutionOrder.Fourth, DataProviderCommandSource.RgtVin);
        }

        public static ISendCommandToBus ForSignioDriversLicenseCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, (int)ExecutionOrder.First, DataProviderCommandSource.SignioDecryptDriversLicense);
        }

        public static ISendCommandToBus ForPCubedCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, (int)ExecutionOrder.First, DataProviderCommandSource.PCubedFica);
        }

        public static ISendCommandToBus ForLightstonePropertyCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, (int)ExecutionOrder.First, DataProviderCommandSource.LightstoneProperty);
        }
    }

    public class BusFactory
    {
        //public static IBus MonitoringBus()
        //{

        //    var assembliesToScan =
        //        AllAssemblies.Matching("Lightstone.DataPlatform.Lace.Shared.command.Monitoring.Messages")
        //            .And("NServiceBus.NHibernate")
        //            .And("NServiceBus.Transports.RabbitMQ");
        //    return
        //        new DataPlatform.Shared.Messaging.RabbitMQ.BusFactory("Monitoring.Messages.Commands", assembliesToScan,
        //            "DataPlatform.command.Monitoring.Host").CreateBusWithNHibernatePersistence();
        //}

        public static IBus WorkflowBus()
        {
            var assembliesToScan =
                AllAssemblies.Matching("Lightstone.DataPlatform.Workflow.Lace.Messages")
                    .And("NServiceBus.NHibernate")
                    .And("NServiceBus.Transports.RabbitMQ");
            return
                new DataPlatform.Shared.Messaging.RabbitMQ.BusFactory("Workflow.Lace.Messages.Commands",
                    assembliesToScan,
                    "DataPlatform.Transactions.Host.Write").CreateBusWithNHibernatePersistence();
        }
    }
}
