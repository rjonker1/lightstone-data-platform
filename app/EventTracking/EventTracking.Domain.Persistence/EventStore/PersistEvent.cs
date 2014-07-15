using System;
namespace EventTracking.Domain.Persistence.EventStore
{
    public class PersistEvent : IPersistEvent
    {
        public void Save(IAggregate aggregate)
        {
            using (var repository = new EventStoreProvider())
            {
                repository.Repository.Write(aggregate, Guid.NewGuid(), d => { });
            }
        }
    }
}
