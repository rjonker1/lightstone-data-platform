using System;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using NServiceBus;

namespace Lace.Test.Helper.Builders.Buses
{
    public class CommandSenderBuilder
    {
        public static ISendCommandsToBus ForIvidCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return new SendIvidCommands(bus,requestId,executionOrder);
        }

        public static ISendCommandsToBus ForIvidTitleHolderCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return new SendIvidTitleHolderCommands(bus, requestId, executionOrder);
        }

        public static ISendCommandsToBus ForRgtCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return new SendRgtCommands(bus, requestId, executionOrder);
        }

        public static ISendCommandsToBus ForRgtVinCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return new SendRgtVinCommands(bus, requestId, executionOrder);
        }


        public static ISendCommandsToBus ForLighstoneCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return new SendLightstoneCommands(bus, requestId, executionOrder);
        }

        public static ISendCommandsToBus ForAudatexCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return new SendLightstoneCommands(bus, requestId, executionOrder);
        }
    }
}
