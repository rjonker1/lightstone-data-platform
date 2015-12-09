using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PackageBuilder.Domain.Entities.Packages.Write;
using Shared.Logging;
using StackExchange.Redis;

namespace PackageBuilder.Infrastructure.NEventStore
{
    public class CacheProvider<T> : ICacheProvider<T> where T : class
    {
        private readonly IDatabase _redisDb;
        public CacheProvider(IDatabase redisDb)
        {
            _redisDb = redisDb;
        }

        public async Task<T> CacheGet(Guid entityId)
        {
            try
            {
                this.Info(() => string.Format("Attempting to retrieve {0}, from cache", entityId));
                var redisValue = await _redisDb.StringGetAsync(entityId + "");
                var cachedEntity = JsonConvert.DeserializeObject<Package>(redisValue.ToString());
                this.Info(() => string.Format("Successfully retrieved {0}, from cache", entityId));
                return cachedEntity as T;
            }
            catch (Exception e)
            {
                this.Error(() => string.Format("Failed to retrieve from cache. {0}", e.Message));
                return null;
            }
        }

        public async void CacheSave(Guid entityId, T entity)
        {
            try
            {
                this.Info(() => string.Format("Attempting to save {0}, to cache", entity));
                var value = JsonConvert.SerializeObject(entity);
                await _redisDb.StringSetAsync(entityId + "", value);
                this.Info(() => string.Format("Successfully saved {0}, to cache", entity));
            }
            catch (Exception e)
            {
                this.Error(() => string.Format("Failed to save to cache. {0}", e.Message));
            }
        }

        public async void CacheDelete(Guid entityId)
        {
            try
            {
                this.Info(() => string.Format("Attempting to delete {0}, from cache", entityId));
                await _redisDb.KeyDeleteAsync(entityId + "");
                this.Info(() => string.Format("Successfully deleted {0}, from cache", entityId));
            }
            catch (Exception e)
            {
                this.Error(() => string.Format("Failed to delete from cache. {0}", e.Message));
            }
        }
    }
}