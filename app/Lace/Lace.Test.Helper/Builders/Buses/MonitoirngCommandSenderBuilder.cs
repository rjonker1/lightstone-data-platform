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
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.Ivid);
        }

        public static ISendCommandToBus ForIvidTitleHolderCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IvidTitleHolder);
        }

        public static ISendCommandToBus ForRgtCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LsaSpecifications);
        }

        public static ISendCommandToBus ForRgtVinCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.VinMaster);
        }


        public static ISendCommandToBus ForLighstoneCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneAuto);
        }

        public static ISendCommandToBus ForAudatexCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.Audatex);
        }

        public static ISendCommandToBus ForSignioCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.SignioDecryptDriversLicense);
        }

        public static ISendCommandToBus ForPCubedCommands(IAdvancedBus bus, Guid requestId, int executionOrder)
        {
            return CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.PCubedFica);
        }
    }
}
