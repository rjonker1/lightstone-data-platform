using System;

namespace EventTracking.Measurement.Streams
{
    public class ExternalSourceEventStreams
    {
        public static Func<string> ExternalSourceExecutionEvents = () => "ExternalSourceExecutionEvents";
        public static Func<string> PublisherExternalSourceExecutionEventPublisherCheckpoint = () => "$publisher-ExternalSourceExecutionEventPublisher-checkpoint";
    }
}
