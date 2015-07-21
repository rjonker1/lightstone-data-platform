using System;
using System.Configuration;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using NEventStore;
using PackageBuilder.Core.Repositories;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;

namespace PackageBuilder.Core.NEventStore
{
    public interface INEventStoreRepository<T> : IRepository, ICacheRepository<T>
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

            this.Info(() => string.Format("Aggregate Cache Read Initialized, TimeStamp: {0}", DateTime.UtcNow));
            var aggregate = CacheGet(id);

            if (aggregate == null)
            {
                this.Info(() => string.Format("Aggregate DB Read Initialized, TimeStamp: {0}", DateTime.UtcNow));
                aggregate = GetById<T>(typeof(T).Name, id);

                // Load aggregate into cache, if it was found in the DB and not originally from Cache
                if (aggregate != null) CacheSave(aggregate);
            }

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
            CacheSave(aggregate as T);

            this.Info(() => string.Format("Successfully to saved {0}", aggregate));
        }

        #region ICacheRepository members

        private static string host = ConfigurationManager.ConnectionStrings["workflow/redis/cache"].ConnectionString;
        private static RedisClient _redisClient = new RedisClient(host);
        private IRedisTypedClient<T> packageClient = _redisClient.As<T>();

        private static bool useCache = true;

        public T CacheGet(Guid entityId)
        {
            if (!useCache) return null;
            try
            {
                this.Info(() => string.Format("Attempting to retrieve {0}, from cache", entityId));
                var cachedPackage = packageClient.GetById(entityId);
                this.Info(() => string.Format("Successfully retrieved {0}, from cache", entityId));
                return cachedPackage;
            }
            catch (Exception e)
            {
                this.Error(() => string.Format("Failed to retrieve from cache. {0}", e.Message));
                useCache = false;
                return null;
            }
        }

        public void CacheSave(T entity)
        {
            if (!useCache) return;
            try
            {
                this.Info(() => string.Format("Attempting to save {0}, to cache", entity.Id));
                packageClient.Store(entity);
                this.Info(() => string.Format("Successfully saved {0}, to cache", entity.Id));
            }
            catch (Exception e)
            {
                this.Error(() => string.Format("Failed to save to cache. {0}", e.Message));
                useCache = false;
            }
        }

        public void CacheDelete(Guid entityId)
        {
            if (!useCache) return;
            try
            {
                this.Info(() => string.Format("Attempting to delete {0}, from cache", entityId));
                packageClient.DeleteById(entityId);
                this.Info(() => string.Format("Successfully deleted {0}, from cache", entityId));
            }
            catch (Exception e)
            {
                this.Error(() => string.Format("Failed to delete from cache. {0}", e.Message));
                useCache = false;
            }
        }
        #endregion
    }
}
