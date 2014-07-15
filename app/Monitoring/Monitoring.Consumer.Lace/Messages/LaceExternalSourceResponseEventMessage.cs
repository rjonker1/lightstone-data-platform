using System;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Messages
{
    public class LaceExternalSourceResponseEventMessage : BaseEventMessage
    {
        public LaceExternalSourceResponseEventMessage(Guid aggregateId, LaceEventSource source, string message,
            string payload,
            int order) :
                base(aggregateId, source, message, order, Categories.LaceExternalSourceResponse)
        {

            Payload = payload;
        }

        public string Payload { get; private set; }
    }
}
