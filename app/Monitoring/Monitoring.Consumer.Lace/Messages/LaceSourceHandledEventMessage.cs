using System;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Messages
{
    public class LaceSourceHandledEventMessage : BaseEventMessage
    {
        public LaceSourceHandledEventMessage(Guid aggregateId, LaceEventSource source, string message, int order) :
            base(aggregateId, source, message, order, Categories.LaceExternalSourceHandled)
        {

        }
    }
}
