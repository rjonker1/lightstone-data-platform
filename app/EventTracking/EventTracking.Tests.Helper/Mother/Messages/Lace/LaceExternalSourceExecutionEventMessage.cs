using System;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;

namespace EventTracking.Tests.Helper.Mother.Messages.Lace
{
    public class LaceEventMessages
    {
        public static LaceExternalSourceExecutionEventMessage ExternalSourceExecutionEventMessage(LaceEventSource source,
            string message, Guid aggregateId)
        {
            return new LaceExternalSourceExecutionEventMessage(aggregateId, source,
                message, 1);
        }
    }
}
