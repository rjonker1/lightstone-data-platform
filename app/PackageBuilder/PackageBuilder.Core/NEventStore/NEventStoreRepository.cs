﻿using System;
using System.Configuration;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
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

        #region ICacheRepository members

        private static string host = ConfigurationManager.ConnectionStrings["workflow/redis/cache"].ConnectionString;
        private static RedisClient _redisClient = new RedisClient(host);
        private IRedisTypedClient<T> packageClient = _redisClient.As<T>();

        public T CacheGet(Guid entityId)
        {
            this.Info(() => string.Format("Attempting to retrieve {0}, from cache", entityId));
            var cachedPackage = packageClient.GetById(entityId);
            return cachedPackage;
        }

        public void CacheSave(T entity)
        {
            this.Info(() => string.Format("Attempting to save {0}, to cache", entity.Id));
            packageClient.Store(entity);
            this.Info(() => string.Format("Successfully saveed {0}, to cache", entity.Id));
        }

        public T CacheDelete(Guid entityId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
