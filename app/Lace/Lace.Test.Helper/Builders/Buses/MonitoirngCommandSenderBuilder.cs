using System;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Shared;

namespace Lace.Test.Helper.Builders.Buses
{
    public class MonitoirngCommandSenderBuilder
    {
        public static ISendCommandToBus ForIvidCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IVIDVerify_E_WS);
        }

        public static ISendCommandToBus ForIvidTitleHolderCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IVIDTitle_E_WS);
        }

        public static ISendCommandToBus ForRgtCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoSpecs_I_DB);
        }

        public static ISendCommandToBus ForRgtVinCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoVINMaster_I_DB);
        }


        public static ISendCommandToBus ForLighstoneCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoCarStats_I_DB);
        }

        public static ISendCommandToBus ForAudatexCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.Audatex);
        }

        public static ISendCommandToBus ForSignioCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoDecryptDriverLic_I_WS);
        }

        public static ISendCommandToBus ForPCubedCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.PCubedFica_E_WS);
        }
    }
}
