using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using DataPlatform.Shared.Helpers.Extensions;
using NEventStore;

namespace PackageBuilder.Core.NEventStore
{
    public interface INEventStoreRepository<T> : IRepository
    {
        T GetById(Guid id);
        T GetById(Guid id, int version);
        void Save(IAggregate aggregate, Guid commitId);
    }

    public class NEventStoreRepository<T> : EventStoreRepository, INEventStoreRepository<T> where T : AggregateBase
    {
        public NEventStoreRepository(IStoreEvents eventStore, IConstructAggregates factory, IDetectConflicts conflictDetector)
            : base(eventStore, factory, conflictDetector)
        {
        }

        public T GetById(Guid id)
        {
            this.Info(() => string.Format("Attempting to get aggregate: {0}", id));

            var aggregate = GetById<T>(typeof(T).Name, id);

            this.Info(() => string.Format("Successfully got aggregate: {0}", id));

            return aggregate;
        }

        public T GetById(Guid id, int version)
        {
            this.Info(() => string.Format("Attempting to get aggregate: {0} version: {1}", id, version));

            var aggregate = GetById<T>(typeof(T).Name, id, version);

            this.Info(() => string.Format("Successfully got aggregate: {0} version: {1}", id, version));

            return aggregate;
        }

        public void Save(IAggregate aggregate, Guid commitId)
        {
            this.Info(() => string.Format("Attempting to save {0}", aggregate));

            this.Save(typeof(T).Name, aggregate, commitId);

            this.Info(() => string.Format("Successfully to saved {0}", aggregate));
        }
    }
}
