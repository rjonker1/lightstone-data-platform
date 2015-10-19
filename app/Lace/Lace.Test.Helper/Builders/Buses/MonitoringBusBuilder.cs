using System;
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
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IVIDVerify_E_WS);
        }

        public static ISendCommandToBus ForAudatexCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.Audatex);
        }

        public static ISendCommandToBus ForLightstoneCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoCarStats_I_DB);
        }

        public static ISendCommandToBus ForVin12Commands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoVINMaster_I_DB);
        }

        public static ISendCommandToBus ForIvidTitleHolderCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IVIDTitle_E_WS);
        }

        public static ISendCommandToBus ForRgtCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoSpecs_I_DB);
        }

        public static ISendCommandToBus ForMmCodeCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.MMCode_E_DB);
        }

        public static ISendCommandToBus ForRgtVinCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoVINMaster_I_DB);
        }

        public static ISendCommandToBus ForSignioDriversLicenseCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoDecryptDriverLic_I_WS);
        }

        public static ISendCommandToBus ForPCubedCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.PCubedFica_E_WS);
        }

        public static ISendCommandToBus ForLightstonePropertyCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSPropertySearch_E_WS);
        }

        public static ISendCommandToBus ForLightstoneCompanyCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSBusinessCompany_E_WS);
        }

        public static ISendCommandToBus ForLightstoneDirectorCommands(Guid requestId)
        {
            var bus = BusFactory.WorkflowBus();
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSBusinessDirector_E_WS);
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
