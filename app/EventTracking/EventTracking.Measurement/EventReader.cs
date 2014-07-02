using System;
using EventStore.ClientAPI;
using EventTracking.Domain.Core;

namespace EventTracking.Measurement
{
    public class EventReader
    {
        private readonly IEventStoreConnection _connection;

        public EventReader(IEventStoreConnection connection)
        {
            if (connection == null) throw new Exception("connection cannot be null");
            _connection = connection;
        }

        public void StartReading()
        {
            _connection.SubscribeToAll(true, Appeared, Dropped, EventStoreCredentials.Default);
        }

        private void Appeared(EventStoreSubscription subscription, ResolvedEvent data)
        {
            var recordedEvent = data.Event;
            if (IsSystemStream(recordedEvent.EventStreamId)) return;

            var linkedStream = data.Link != null ? data.Link.EventStreamId : null;
            if (IsSystemStream(linkedStream)) return;

            Console.WriteLine("{0}: {1}",recordedEvent.EventType, FormatStream(linkedStream, recordedEvent));
        }

        private static string FormatStream(string linkedStream, RecordedEvent recordedEvent)
        {
            return linkedStream == null
                ? "stream: " + recordedEvent.EventStreamId
                : "link: " + linkedStream;
        }

        private static bool IsSystemStream(string linkedStream)
        {
            return linkedStream != null && linkedStream.StartsWith("$");
        }

        private static void Dropped(EventStoreSubscription subscription, SubscriptionDropReason subscriptionDropReason, Exception exception)
        {
            var message = string.Format("Subscription {0} dropped: {1} (Recovery currently not implemented){2}{3}",
                subscription.StreamId, subscriptionDropReason, Environment.NewLine, exception);

            Console.WriteLine(message);
        }
    }
}
