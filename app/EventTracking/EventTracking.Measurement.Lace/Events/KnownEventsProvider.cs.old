using System;
using EventStore.ClientAPI;
using EventTracking.Domain.Read.Core;
using Monitoring.Events.Lace;

namespace EventTracking.Measurement.Lace.Events
{
    public class KnownEventsProvider : IKnownEventsProvider
    {
        public KnownEvent Get(RecordedEvent recordedEvent)
        {
            if (recordedEvent.EventType == "ExternalSourceEvent")
            {
                return new KnownEvent<ExternalSourceEvent>(ConsoleColor.Green, recordedEvent);
            }
            if (recordedEvent.EventType == "ExternalSourceFailedEvent")
            {
                return new KnownEvent<ExternalSourceFailedEvent>(ConsoleColor.Magenta, recordedEvent);
            }
            if (recordedEvent.EventType == "ExternalSourceHandledEvent")
            {
                return new KnownEvent<ExternalSourceHandledEvent>(ConsoleColor.Magenta, recordedEvent);
            }
            if (recordedEvent.EventType == "ExternalSourceRequestSentEvent")
            {
                return new KnownEvent<ExternalSourceRequestSentEvent>(ConsoleColor.Red, recordedEvent);
            }

            if (recordedEvent.EventType == "ExternalSourceResponseFailureEvent")
            {
                return new KnownEvent<ExternalSourceResponseFailureEvent>(ConsoleColor.White, recordedEvent);
            }

            if (recordedEvent.EventType == "ExternalSourceResponseSuccessEvent")
            {
                return new KnownEvent<ExternalSourceResponseSuccessEvent>(ConsoleColor.Yellow, recordedEvent);
            }

            if (recordedEvent.EventType == "ExternalSourceResponseTransformationEvent")
            {
                return new KnownEvent<ExternalSourceResponseTransformationEvent>(ConsoleColor.Cyan, recordedEvent);
            }

            return new KnownEvent(ConsoleColor.Yellow);
        }
    }
}
