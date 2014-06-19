using System;
using EventTracking.Domain;
using EventTracking.Domain.Persistence.EventStore;

namespace Monitoring.Consumer.Lace.Persistence
{
    public class PersistEvent : IPersistEvent
    {
        public void Save(IAggregate aggregate)
        {
            using (var repository = new EventStoreProvider())
            {
                repository.Instance().Repository.Write(aggregate, Guid.NewGuid(), d => { });
            }
        }
    }
}
