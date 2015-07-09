using System;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts.Caching;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Caching.BuildingBlocks.Repository
{
    public class CacheDataRepository : ICacheRepository
    {
        private readonly ILog _log;
        private const string CacheIp = "127.0.0.1:6379";

        public CacheDataRepository()
        {
            _log = LogManager.GetLogger(GetType());
        }
        
        public static CacheDataRepository ForCacheOnly()
        {
            return new CacheDataRepository();
        }

        public void AddItemsForEach<TItem>(string sql) where TItem : class
        {
            try
            {
                using (var manager = new PooledRedisClientManager(1000, 10, new[] { CacheIp }) { ConnectTimeout = 1000 })
                {
                    using (var redis = manager.GetClient())
                    {
                        var type = redis.As<TItem>();

                        using (var connection = ConnectionFactoryManager.AutocarStatsConnection)
                        {
                            var dbResponse = connection.Query<TItem>(sql).ToList();

                            _log.InfoFormat("Trying to add {0} to the cache. Number of rows {1}", typeof (TItem).FullName, dbResponse.Count);

                            dbResponse.ForEach(f => type.Store(f));

                            _log.InfoFormat("Added {0} to the cache. Number of rows {1}", typeof (TItem).FullName, dbResponse.Count);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Cannot Add Items to Cache because of {0}", ex, ex.Message);
            }
        }

        public void AddItems<TItem>(string sql) where TItem : class
        {
            try
            {
                using (var manager = new PooledRedisClientManager(1000, 10, new[] { CacheIp }) { ConnectTimeout = 1000 })
                {
                    using (var redis = manager.GetClient())
                    {
                        var type = redis.As<TItem>();

                        using (var connection = ConnectionFactoryManager.AutocarStatsConnection)
                        {
                            var dbResponse = connection.Query<TItem>(sql).ToList();

                            _log.InfoFormat("Trying to add {0} to the cache. Number of rows {1}", typeof (TItem).FullName, dbResponse.Count);

                            type.StoreAll(dbResponse);

                            _log.InfoFormat("Added {0} to the cache. Number of rows {1}", typeof (TItem).FullName, dbResponse.Count);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Cannot Add Items to Cache because of {0}", ex, ex.Message);
            }
        }

        public void ClearAll()
        {
            try
            {
                using (var client = new RedisClient(CacheIp))
                {
                    client.FlushDb();
                    client.FlushAll();
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Cannot Clear All the Items from the Cache becuse of {0}", ex, ex.Message);
            }
        }

        public void AddItemWithKey<TItem>(string key, TItem item, DateTime expiresAt) where TItem : class
        {
            try
            {
                using (var client = new RedisClient(CacheIp))
                {
                    var cachedItem = client.As<TItem>();
                    var response = cachedItem.Lists[key];
                    response.Add(item);
                    client.Add(key, response, expiresAt);
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Cannot Clear All the Items from the Cache becuse of {0}", ex, ex.Message);
            }
        }
    }
}
