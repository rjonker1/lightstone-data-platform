using System;
using EventTracking.Domain;
using EventTracking.Domain.Persistence.Storage.Providers;

namespace Monitoring.Consumer.Lace.Persistence
{
    public class PersistEvent : IPersistEvent
    {
        public void Save(IAggregate aggregate)
        {
            using (var repository = new EventStoreConnectionFactory())
            {
                repository.Instance().Repository.Save(aggregate, Guid.NewGuid(), d => { });
            }
        }
    }
}
