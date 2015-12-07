using System;
using Lim.Domain.Base;

namespace Lim.Domain.EventStore
{
    public class AggregateRepository<T> : IAggregateRepository<T> where T : Aggregate, new()
    {
        private readonly IEventStore _storage;

        public AggregateRepository(IEventStore storage)
        {
            _storage = storage;
        }

        public void Save(Aggregate aggregate, long expectedVersion)
        {
            _storage.SaveEvents(aggregate.Id, aggregate.GetUncommittedEvents(), expectedVersion);
        }

        public T GetById(Guid id)
        {
            var obj = new T();
            var e = _storage.GetEventsForAggregate(id);
            obj.LoadsFromHistory(e);
            return obj;
        }
    }
}
