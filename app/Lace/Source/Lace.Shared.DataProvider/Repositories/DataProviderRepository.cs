using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Shared.DataProvider.Repositories
{
    public class DataProviderRepository : IReadOnlyRepository
    {
        private const string CacheIp = "127.0.0.1:6379";
        private static readonly ILog Log = LogManager.GetLogger<DataProviderRepository>();

        public DataProviderRepository()
        {
           
        }

        public IEnumerable<TItem> GetAll<TItem>(Func<TItem, bool> predicate) where TItem : class
        {
            try
            {
                using (var client = new RedisClient(CacheIp))
                {
                    return predicate != null
                        ? client.As<TItem>().GetAll().Where(predicate)
                        : client.As<TItem>().GetAll();
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Could not get items from the cache because of {0}", ex.Message, ex);
            }
            return Enumerable.Empty<TItem>();
        }

        public IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            try
            {
                using(var connection = ConnectionFactoryManager.AutocarStatsConnection)
                    return connection.Query<TItem>(sql, param);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Could not get items from database because of {0}", ex.Message, ex);
            }

            return Enumerable.Empty<TItem>();
        }

        public static TItem GetKeyFromCache<TItem>(string key) where TItem : class
        {
            try
            {
                using (var client = new RedisClient(CacheIp))
                {
                    var cachedItem = client.As<TItem>();
                    var response = cachedItem.Lists[key];

                    if (response != null && response.Any())
                        return response.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Could not get items from Cache because of {0}", ex.Message, ex);
            }

            return null;
        }
    }
}