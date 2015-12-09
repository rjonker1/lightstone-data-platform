using System;
using System.Threading.Tasks;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using NEventStore;
using Shared.Logging;

namespace PackageBuilder.Infrastructure.NEventStore
{
    public interface INEventStoreRepository<T> : IRepository
    {
        T GetById(Guid id);
        Task<T> GetByIdCached(Guid id);
        T GetById(Guid id, int version);
        void Save(IAggregate aggregate, Guid commitId, bool useCache = false);
    }

    public class NEventStoreRepository<T> : EventStoreRepository, INEventStoreRepository<T> where T : AggregateBase
    {
        private readonly ICacheProvider<T> _cacheProvider; 
        public NEventStoreRepository(IStoreEvents eventStore, IConstructAggregates factory, IDetectConflicts conflictDetector, ICacheProvider<T> cacheProvider)
            : base(eventStore, factory, conflictDetector)
        {
            _cacheProvider = cacheProvider;
        }

        public async Task<T> GetByIdCached(Guid id)
        {
            this.Info(() => string.Format("Aggregate Cache Read Started, TimeStamp: {0}", DateTime.UtcNow));

            var aggregate = await _cacheProvider.CacheGet(id);

            this.Info(() => string.Format("Aggregate Cache Read Finished, TimeStamp: {0}", DateTime.UtcNow));

            if (aggregate == null)
            {
                aggregate = GetById<T>(id);
                _cacheProvider.CacheSave(id, aggregate);
            }

            return aggregate;
        }

        public T GetById(Guid id)
        {
            this.Info(() => string.Format("Getting aggregate: {0}", id));

            var aggregate = GetById<T>(typeof(T).Name, id);

            this.Info(() => string.Format("Got aggregate: {0}", id));

            return aggregate;
        }

        public T GetById(Guid id, int version)
        {
            this.Info(() => string.Format("Getting aggregate: {0} version: {1}", id, version));

            var aggregate = GetById<T>(typeof(T).Name, id, version);

            this.Info(() => string.Format("Got aggregate: {0} version: {1}", id, version));

            return aggregate;
        }

        public void Save(IAggregate aggregate, Guid commitId, bool useCache = false)
        {
            this.Info(() => string.Format("Attempting to save {0}", aggregate));

            this.Save(typeof(T).Name, aggregate, commitId);
            if (useCache) _cacheProvider.CacheSave(commitId, aggregate as T);

            this.Info(() => string.Format("Successfully to saved {0}", aggregate));
        }
    }
}

