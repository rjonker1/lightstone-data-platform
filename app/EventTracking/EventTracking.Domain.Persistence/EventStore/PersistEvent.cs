using System;
namespace EventTracking.Domain.Persistence.EventStore
{
    public class PersistEvent : IPersistAnEvent
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
