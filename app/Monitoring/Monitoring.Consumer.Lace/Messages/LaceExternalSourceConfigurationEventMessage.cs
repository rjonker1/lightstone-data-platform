using System;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Messages
{
    public class LaceExternalSourceConfigurationEventMessage : BaseEventMessage
    {
        public LaceExternalSourceConfigurationEventMessage(Guid aggregateId, LaceEventSource source, string message, int order) :
            base(aggregateId, source, message, order, Categories.LaceExternalSourceConfiguration)
        {
          
        }
    }
}
