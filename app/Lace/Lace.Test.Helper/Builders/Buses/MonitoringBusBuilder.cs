﻿using System;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Shared;

namespace Lace.Test.Helper.Builders.Buses
{
    public class MonitoringBusBuilder
    {
        public static ISendCommandToBus ForIvidCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.Ivid);
        }

        public static ISendCommandToBus ForAudatexCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.Audatex);
        }

        public static ISendCommandToBus ForLightstoneCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneAuto);
        }

        public static ISendCommandToBus ForIvidTitleHolderCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IvidTitleHolder);
        }

        public static ISendCommandToBus ForRgtCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LsaSpecifications);
        }

        public static ISendCommandToBus ForRgtVinCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.VinMaster);
        }

        public static ISendCommandToBus ForSignioDriversLicenseCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.SignioDecryptDriversLicense);
        }

        public static ISendCommandToBus ForPCubedCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.PCubedFica);
        }

        public static ISendCommandToBus ForLightstonePropertyCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneProperty);
        }

        public static ISendCommandToBus ForLightstoneCompanyCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneBusinessCompany);
        }

        public static ISendCommandToBus ForLightstoneDirectorCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneBusinessDirector);
        }
    }

    public class BusFactory
    {

        public static IAdvancedBus WorkflowBus()
        {
            return Workflow.BuildingBlocks.BusFactory.CreateAdvancedBus("workflow/dataprovider/queue");
        }
    }
}
