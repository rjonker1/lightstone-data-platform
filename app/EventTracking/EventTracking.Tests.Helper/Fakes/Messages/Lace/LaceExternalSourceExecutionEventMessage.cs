using System;
using Monitoring;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;

namespace EventTracking.Tests.Helper.Fakes.Messages.Lace
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
