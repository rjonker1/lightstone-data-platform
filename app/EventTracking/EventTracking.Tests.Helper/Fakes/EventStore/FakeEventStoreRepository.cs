using System;
using System.Collections.Generic;
using System.Linq;
using EventTracking.Domain;
using EventTracking.Domain.Core;
using EventTracking.Domain.Persistence;

namespace EventTracking.Tests.Helper.Fakes.EventStore
{
    public class FakeEventStoreRepository : IWriteToEventTrackingRepository
    {
        private readonly Func<string, Guid, string> _aggregateIdToStreamName;


        public FakeEventStoreRepository() : this((t, g) => string.Format("{0}-{1}",t,g.ToString("N")))
        {
            
        }

        public FakeEventStoreRepository(Func<string, Guid, string> streamName)
        {
            _aggregateIdToStreamName = streamName;
        }


        public void Write(IAggregate aggregate, Guid commitId, Action<IDictionary<string, object>> updateHeaders)
        {
            var streamName = _aggregateIdToStreamName(aggregate.Category, aggregate.Id);
            var newEvents = aggregate.GetUncommittedEvents().Cast<object>().ToList();

            var eventsToSave = newEvents
                .Select(e => e.AsJsonEvent())
                .ToList();

            foreach (var eventData in eventsToSave)
            {
                var data = new StreamData(streamName, eventData);

                FakeDatabase.Events.Add(Guid.NewGuid(), data);
            }

            aggregate.ClearUncommittedEvents();
        }
    }
}
