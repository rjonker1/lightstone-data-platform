using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain;
using CommonDomain.Persistence;

namespace Monitoring.Test.Helper.Fakes.EventStore
{
    public class FakeEventStoreRepository : IRepository
    {
        public TAggregate GetById<TAggregate>(Guid id, int version) where TAggregate : class, IAggregate
        {
            throw new NotImplementedException();
        }

        public TAggregate GetById<TAggregate>(Guid id) where TAggregate : class, IAggregate
        {
            return (TAggregate)FakeDatabase.Events.FirstOrDefault(f => f.Value.Id == id).Value;
        }

        public void Save(IAggregate aggregate, Guid commitId, Action<IDictionary<string, object>> updateHeaders)
        {
            FakeDatabase.Events.Add(commitId, aggregate);
            aggregate.ClearUncommittedEvents();
        }

        //private readonly Func<Guid, string> _aggregateIdToStreamName;


        //public FakeEventStoreRepository()
        //    : this((t, g) => string.Format("{0}-{1}", t, g.ToString("N")))
        //{

        //}

        //public FakeEventStoreRepository(Func<Guid, string> streamName)
        //{
        //    _aggregateIdToStreamName = streamName;
        //}


        //public void Write(IAggregate aggregate, Guid commitId, Action<IDictionary<string, object>> updateHeaders)
        //{
        //    var streamName = _aggregateIdToStreamName(aggregate.Category, aggregate.Id);
        //    var newEvents = aggregate.GetUncommittedEvents().Cast<object>().ToList();

        //    var eventsToSave = newEvents
        //        .Select(e => e.AsJsonEvent())
        //        .ToList();

        //    foreach (var eventData in eventsToSave)
        //    {
        //        var data = new StreamData(streamName, eventData);

        //        FakeDatabase.Events.Add(Guid.NewGuid(), data);
        //    }

        //    aggregate.ClearUncommittedEvents();
        //}

        
    }
}
