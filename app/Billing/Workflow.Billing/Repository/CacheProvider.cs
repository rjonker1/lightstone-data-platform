using System;
using System.Configuration;
using DataPlatform.Shared.Helpers.Extensions;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;

namespace Workflow.Billing.Repository
{
    public class CacheProvider<T> : ICacheProvider<T> where T : class 
    {
        private static RedisClient _redisClient;
        private readonly IRedisTypedClient<T> cacheClient;

        private static bool useCache = true;

        public CacheProvider()
        {
            try
            {
                string host = ConfigurationManager.ConnectionStrings["workflow/redis/cache"].ConnectionString;
                _redisClient = new RedisClient(host);
                cacheClient = _redisClient.As<T>();
            }
            catch (Exception ex)
            {
                this.Error(() => string.Format("Failed to initialize CacheProvider. {0}", ex.Message));
                useCache = false;
            }
        }

        public T CacheGet(Guid entityId)
        {
            if (!useCache) return null;
            try
            {
                this.Info(() => string.Format("Attempting to retrieve {0}, from cache", entityId));
                var cachedEntity = cacheClient.GetById(entityId);
                this.Info(() => string.Format("Successfully retrieved {0}, from cache", entityId));
                return cachedEntity;
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
                this.Info(() => string.Format("Attempting to save {0}, to cache", entity));
                cacheClient.Store(entity);
                this.Info(() => string.Format("Successfully saved {0}, to cache", entity));
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
                cacheClient.DeleteById(entityId);
                this.Info(() => string.Format("Successfully deleted {0}, from cache", entityId));
            }
            catch (Exception e)
            {
                this.Error(() => string.Format("Failed to delete from cache. {0}", e.Message));
                useCache = false;
            }
        }
    }
}