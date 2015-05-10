using System;
using System.Data;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Shared.DataProvider.Contracts;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Caching.BuildingBlocks.Repository
{
    public class CacheDataRepository : ICacheRepository
    {
        private readonly IDbConnection _connection;
        private readonly ILog _log;
        private const string CacheIp = "127.0.0.1:6379";

        public CacheDataRepository(IDbConnection connection)
        {
            _connection = connection;
            _log = LogManager.GetLogger(GetType());
        }

        public void AddItemsForEach<TItem>(string sql) where TItem : class
        {
            using (var redisManager = new PooledRedisClientManager(1000, 10, new[] { CacheIp }) { ConnectTimeout = 1000 })
            {
                using (var redis = redisManager.GetClient())
                {
                    var type = redis.As<TItem>();

                    var dbResponse =
                        _connection.Query<TItem>(sql).ToList();

                    _log.InfoFormat("Trying to add {0} to the cache. Number of rows {1}", typeof(TItem).FullName, dbResponse.Count);

                    dbResponse.ForEach(f => type.Store(f));

                    _log.InfoFormat("Added {0} to the cache. Number of rows {1}", typeof(TItem).FullName, dbResponse.Count);
                }
            }

        }

        public void AddItems<TItem>(string sql) where TItem : class
        {
            try
            {
                using (var redisManager = new PooledRedisClientManager(1000, 10, new[] {CacheIp}) {ConnectTimeout = 1000})
                {
                    using (var redis = redisManager.GetClient())
                    {
                        var type = redis.As<TItem>();

                        var dbResponse =
                            _connection.Query<TItem>(sql).ToList();

                        _log.InfoFormat("Trying to add {0} to the cache. Number of rows {1}", typeof (TItem).FullName, dbResponse.Count);

                        type.StoreAll(dbResponse);

                        _log.InfoFormat("Added {0} to the cache. Number of rows {1}", typeof (TItem).FullName, dbResponse.Count);
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
                using (var client = CacheConnectionFactory.LocalClient().GetClient())
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

       
    }
}
