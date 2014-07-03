using System;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Messages
{
    public class LaceExternalSourceFailedEventMessage : BaseEventMessage
    {
        public LaceExternalSourceFailedEventMessage(Guid aggregateId, LaceEventSource source, string message, int order)
            :
                base(aggregateId, source, message, order, "laceExternalSourceFailure")
        {

        }
    }
}
