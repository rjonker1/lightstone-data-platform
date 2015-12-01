using System;
using System.Threading.Tasks;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using DataPlatform.Shared.Enums;
using NEventStore;
using Shared.Logging;

namespace PackageBuilder.Infrastructure.NEventStore
{
    public interface INEventStoreRepository<T> : IRepository
    {
        Task<T> GetById(Guid id, bool useCache = false);
        //T GetById(Guid id, int version, bool useCache = false);
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

        public async Task<T> GetById(Guid id, bool useCache = false)
        {
            this.Info(() => string.Format("Attempting to get aggregate: {0}", id), SystemName.PackageBuilder);

            this.Info(() => string.Format("Aggregate Cache Read Initialized, TimeStamp: {0}", DateTime.UtcNow), SystemName.PackageBuilder);

            var aggregate = default(T);

            if (useCache) aggregate = await _cacheProvider.CacheGet(id);

            if (aggregate == null)
            {
                this.Info(() => string.Format("Aggregate DB Read Initialized, TimeStamp: {0}", DateTime.UtcNow), SystemName.PackageBuilder);
                aggregate = GetById<T>(typeof(T).Name, id);

                // Load aggregate into cache, if it was found in the DB and not originally from Cache
                if (aggregate != null && useCache) _cacheProvider.CacheSave(id, aggregate);
            }

            this.Info(() => string.Format("Successfully got aggregate: {0}", id), SystemName.PackageBuilder);

            return aggregate;
        }

        //public T GetById(Guid id, int version)
        //{
        //    this.Info(() => string.Format("Attempting to get aggregate: {0} version: {1}", id, version));

        //    var aggregate = GetById<T>(typeof(T).Name, id, version);

        //    this.Info(() => string.Format("Successfully got aggregate: {0} version: {1}", id, version));

        //    return aggregate;
        //}

        public void Save(IAggregate aggregate, Guid commitId, bool useCache = false)
        {
            this.Info(() => string.Format("Attempting to save {0}", aggregate), SystemName.PackageBuilder);

            this.Save(typeof(T).Name, aggregate, commitId);
            if (useCache) _cacheProvider.CacheSave(commitId, aggregate as T);

            this.Info(() => string.Format("Successfully to saved {0}", aggregate), SystemName.PackageBuilder);
        }
    }
}

