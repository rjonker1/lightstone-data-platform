using System;
using EventTracking.Domain;
using EventTracking.Domain.Persistence;
using EventTracking.Domain.Persistence.Storage.Providers;

namespace Monitoring.Consumer.Lace.Persistence
{
    public class PersistEvent : IPersistEvent
    {
        private static IRepository Repository
        {
            get
            {
                return new RepositoryFactory()
                    .Instance()
                    .Repository;
            }
        }

        public void Save(IAggregate aggregate)
        {
            Repository
                .Save(aggregate, Guid.NewGuid(), d => { });
        }
    }
}
