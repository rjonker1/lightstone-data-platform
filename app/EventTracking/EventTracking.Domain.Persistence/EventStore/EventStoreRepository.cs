using System;
using System.Collections.Generic;
using System.Linq;
using EventStore.ClientAPI;
using EventTracking.Domain.Core;

namespace EventTracking.Domain.Persistence.EventStore
{
    public class EventStoreRepository : IWriteToEventTrackingRepository, IDisposable
    {
        private readonly Func<string, Guid, string> _aggregateIdToStreamName;
        private readonly IEventStoreConnection _eventStoreConnection;
   
        public EventStoreRepository(IEventStoreConnection eventStoreConnection)
            : this(
                eventStoreConnection,
                (t, g) => string.Format("{0}-{1}", t, g.ToString("N")))
        {
        }


        public EventStoreRepository(IEventStoreConnection eventStoreConnection,
            Func<string, Guid, string> aggregateIdToStreamName)
        {
            _eventStoreConnection = eventStoreConnection;
            _aggregateIdToStreamName = aggregateIdToStreamName;
        }


        public void Write(IAggregate aggregate, Guid commitId, Action<IDictionary<string, object>> updateHeaders)
        {
            var streamName = _aggregateIdToStreamName(aggregate.Category, aggregate.Id);
            var newEvents = aggregate.GetUncommittedEvents().Cast<object>().ToList();
          

            var eventsToSave = newEvents.Select(e => e.AsJsonEvent()).ToList();

            _eventStoreConnection.AppendToStream(streamName, ExpectedVersion.Any, eventsToSave);

            aggregate.ClearUncommittedEvents();
        }
       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            _eventStoreConnection.Close();
        }
    }
}
