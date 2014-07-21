using System;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Messages
{
    public class LaceTransformResponseEventMessage : BaseEventMessage
    {
        public LaceTransformResponseEventMessage(Guid aggregateId, LaceEventSource source, string message, int order) :
            base(aggregateId, source, message, order, Categories.LaceExternalSourceTransformation)
        {

        }
    }
}
