using System;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Messages
{
    public class LaceExternalSourceRequestEventMessage : BaseEventMessage
    {
        public LaceExternalSourceRequestEventMessage(Guid aggregateId, LaceEventSource source, string message,
            string payload, int order) :
                base(aggregateId, source, message, order, "laceExternalSourceRequest")
        {
            Payload = payload;
        }

        public string Payload { get; private set; }
    }
}
