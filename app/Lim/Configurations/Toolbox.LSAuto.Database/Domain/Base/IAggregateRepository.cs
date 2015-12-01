using System;
namespace Toolbox.LightstoneAuto.Database.Domain.Base
{
    public interface IAggregateRepository<out T> where T : Aggregate, new()
    {
        void Save(Aggregate aggregate, int expectedVersion);
        T GetById(Guid id);
    }

    public class AggregateRepository<T> : IAggregateRepository<T> where T : Aggregate, new()
    {
        private readonly IEventStore _storage;

        public AggregateRepository(IEventStore storage)
        {
            _storage = storage;
        }

        public void Save(Aggregate aggregate, int expectedVersion)
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
