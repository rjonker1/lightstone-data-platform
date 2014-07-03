using System;
using EventStore.ClientAPI;
using EventTracking.Domain.Core;
using EventTracking.Measurement.Lace.Events;

namespace EventTracking.Measurement.Lace.Queries
{
    public class ExternalSourceExecutionDetectedQuery
    {

        private readonly IEventStoreConnection _connection;
        private readonly IProjectionContext _projectionContext;

        public ExternalSourceExecutionDetectedQuery(IEventStoreConnection connection, IProjectionContext projectionContext)
        {
            _connection = connection;
            _projectionContext = projectionContext;
        }

        public ExternalSourceEventRead GetValue()
        {
            return _projectionContext.GetState<ExternalSourceEventRead>("ExternalSourceEventRead");
        }

        public void SubscribeToEvent(Action<ExternalSourceEventRead> readEvent)
        {
            _connection.SubscribeToStream("ExternalSourceEvents", false,
                (s, @event) => EventReader(s, @event, readEvent), Dropped, EventStoreCredentials.Default);
        }

        private static void Dropped(EventStoreSubscription subscription, SubscriptionDropReason subscriptionDropReason,
            Exception exception)
        {
            Console.WriteLine("Subscription {0} dropped: {1} (Currently no recovery implemented){2}{3}",
                subscription.StreamId, subscriptionDropReason, Environment.NewLine, exception);
        }

        private static void EventReader(EventStoreSubscription eventStoreSubscription, ResolvedEvent resolvedEvent,
            Action<ExternalSourceEventRead> readEvent)
        {
            var value = resolvedEvent.ParseJson<ExternalSourceEventRead>();
            readEvent(value);
        }

        //private readonly IEventStoreConnection _connection;

        //public SourceRequestQuery(IEventStoreConnection connection)
        //{
        //    if (connection == null) throw new ArgumentNullException("connection");

        //    _connection = connection;
        //}

        //public IEnumerable<EventsPublishedForLaceRequests> GetValues(string sourceName)
        //{
        //    var projectionResultStream = string.Format("ExternalSourceExecutionTime-{0}", sourceName);



        //    return _connection.ReadStreamEventsBackward<EventsPublishedForLaceRequests>(projectionResultStream);
        //}
    }
}
