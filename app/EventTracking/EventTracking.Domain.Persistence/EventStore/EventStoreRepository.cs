using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace EventTracking.Domain.Persistence.EventStore
{
    public class EventStoreRepository : IRepository, IDisposable
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
          

            var eventsToSave = newEvents.Select(e => ToEventData(e)).ToList();

            _eventStoreConnection.AppendToStream(streamName, ExpectedVersion.Any, eventsToSave);

            aggregate.ClearUncommittedEvents();
        }

        private static EventData ToEventData(object evnt)
        {
            var @event = JsonEvent(evnt);
            return @event;
        }

        private static EventData AsJsonEvent(string value, string eventName)
        {
            var bytes = Encoding.UTF8.GetBytes(value);

            return new EventData(Guid.NewGuid(), eventName, true, bytes, null);
        }

        private static EventData JsonEvent(object value)
        {
            var json = JsonConvert.SerializeObject(value);
            var eventName = value.GetType().Name;

            return AsJsonEvent(json, eventName);
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
