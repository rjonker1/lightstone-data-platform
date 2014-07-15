using System;
using Monitoring.Consumer.Lace.Messages;
using Monitoring.Sources.Lace;

namespace EventTracking.Tests.Helper.Builder.Lace
{
    public class EventMessagesBuilder
    {
        private readonly Guid _aggregateId;

        public EventMessagesBuilder(Guid aggregateId)
        {
            _aggregateId = aggregateId;
        }

        public LaceExternalSourceExecutionEventMessage ForIvidStartCallingExternalSourceEvent()
        {
            return Mother.Messages.Lace.LaceEventMessages.ExternalSourceExecutionEventMessage(LaceEventSource.Ivid,
                PublishableLaceMessages.StartCallingExternalSource, _aggregateId);
        }

    }
}
