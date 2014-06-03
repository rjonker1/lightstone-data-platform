using System;
using EventTracking.Domain;
using EventTracking.Domain.Persistence;
using EventTracking.Domain.Persistence.Storage.Providers;

namespace Monitoring.Modules.Lace.AggregatePersistence
{
    public class PersistAggregate : IPersistAggregate
    {
        private readonly IAggregate _aggregate;

        public PersistAggregate(IAggregate aggregate)
        {
            _aggregate = aggregate;
        }


        public IRepository Repository
        {
            get
            {
                return new RepositoryFactory()
                    .Instance()
                    .Repository;
            }
        }

        public void SaveAggregate()
        {
            Repository
                .Save(_aggregate, Guid.NewGuid(), d => { });
        }
    }
}
