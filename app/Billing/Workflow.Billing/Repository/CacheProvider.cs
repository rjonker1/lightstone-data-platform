using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Repositories;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;

namespace Workflow.Billing.Repository
{
    public class CacheProvider<T> : ICacheProvider<T> where T : class
    {
        public static RedisClient _redisClient;
        //public readonly IRedisTypedClient<T> cacheClient;

        public IRedisTypedClient<T> CacheClient { get; set; }

        private static bool useCache = true;

        public CacheProvider()
        {
            try
            {
                string host = ConfigurationManager.ConnectionStrings["workflow/redis/cache"].ConnectionString;
                _redisClient = new RedisClient(host);
                CacheClient = _redisClient.As<T>();
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
                var cachedEntity = CacheClient.GetById(entityId);
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
                CacheClient.Store(entity);
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
                CacheClient.DeleteById(entityId);
                this.Info(() => string.Format("Successfully deleted {0}, from cache", entityId));
            }
            catch (Exception e)
            {
                this.Error(() => string.Format("Failed to delete from cache. {0}", e.Message));
                useCache = false;
            }
        }

        public async Task<bool> CachePipelineInsert(IRepository<T> typedEntityRepository)
        {
            try
            {
                using (var client = CacheClient)
                using (var pipeline = client.CreatePipeline())
                {
                    foreach (var record in typedEntityRepository)
                    {
                        if (record != null)
                            pipeline.QueueCommand(c => c.Store(record));
                    }

                    pipeline.Flush();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}