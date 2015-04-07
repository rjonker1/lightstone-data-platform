using System;
using DataPlatform.Shared.Enums;
using NServiceBus;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Shared;

namespace Lace.Test.Helper.Builders.Buses
{
    public class MonitoirngCommandSenderBuilder
    {
        public static ISendCommandToBus ForIvidCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, executionOrder, DataProviderCommandSource.Ivid);
        }

        public static ISendCommandToBus ForIvidTitleHolderCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, executionOrder, DataProviderCommandSource.IvidTitleHolder);
        }

        public static ISendCommandToBus ForRgtCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, executionOrder, DataProviderCommandSource.Rgt);
        }

        public static ISendCommandToBus ForRgtVinCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, executionOrder, DataProviderCommandSource.RgtVin);
        }


        public static ISendCommandToBus ForLighstoneCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, executionOrder, DataProviderCommandSource.LightstoneAuto);
        }

        public static ISendCommandToBus ForAudatexCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, executionOrder, DataProviderCommandSource.Audatex);
        }

        public static ISendCommandToBus ForSignioCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, executionOrder, DataProviderCommandSource.SignioDecryptDriversLicense);
        }

        public static ISendCommandToBus ForPCubedCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, executionOrder, DataProviderCommandSource.PCubedFica);
        }
    }
}
