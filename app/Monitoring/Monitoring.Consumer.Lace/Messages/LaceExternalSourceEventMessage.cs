using System;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Messages
{
    public class LaceExternalSourceEventMessage : BaseEventMessage
    {
        public LaceExternalSourceEventMessage(Guid aggregateId, LaceEventSource source, string message, int order) :
            base(aggregateId, source, message, order, "laceExternalSource")
        {

        }
    }
}
