using System;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using NServiceBus;

namespace Lace.Test.Helper.Builders.Buses
{
    public class MonitoirngCommandSenderBuilder
    {
        public static ISendMonitoringCommandsToBus ForIvidCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return new SendIvidCommands(bus,requestId,executionOrder);
        }

        public static ISendMonitoringCommandsToBus ForIvidTitleHolderCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return new SendIvidTitleHolderCommands(bus, requestId, executionOrder);
        }

        public static ISendMonitoringCommandsToBus ForRgtCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return new SendRgtCommands(bus, requestId, executionOrder);
        }

        public static ISendMonitoringCommandsToBus ForRgtVinCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return new SendRgtVinCommands(bus, requestId, executionOrder);
        }


        public static ISendMonitoringCommandsToBus ForLighstoneCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return new SendLightstoneCommands(bus, requestId, executionOrder);
        }

        public static ISendMonitoringCommandsToBus ForAudatexCommands(IBus bus, Guid requestId, int executionOrder)
        {
            return new SendLightstoneCommands(bus, requestId, executionOrder);
        }
    }
}
