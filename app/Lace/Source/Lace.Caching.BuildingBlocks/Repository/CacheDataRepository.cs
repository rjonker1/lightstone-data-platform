using System;
using System.Data;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Shared.DataProvider.Contracts;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Caching.BuildingBlocks.Repository
{
    public class CacheDataRepository : ICacheRepository
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;
        private readonly ILog _log;

        public CacheDataRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
            _log = LogManager.GetLogger(GetType());
        }

        public void AddItems<TItem>(string sql) where TItem : class
        {
            try
            {
                var type = _cacheClient.GetTypedClient<TItem>() ?? new RedisTypedClient<TItem>(new RedisClient(CacheConnectionFactory.CacheIp));
                using (type)
                {
                    var dbResponse =
                        _connection.Query<TItem>(sql).ToList();

                    _log.InfoFormat("Trying to add {0} to the cache. Number of rows {1}", typeof (TItem).FullName, dbResponse.Count);

                    type.StoreAll(dbResponse);

                    _log.InfoFormat("Added {0} to the cache. Number of rows {1}", typeof (TItem).FullName, dbResponse.Count);
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
                using (_cacheClient)
                {
                    _cacheClient.FlushAll();
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Cannot Clear All the Items from the Cache becuse of {0}", ex,ex.Message);
            }
        }
    }
}
