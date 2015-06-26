﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Castle.DynamicProxy.Internal;
using Common.Logging;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Shared.DataProvider.Repositories
{
    public class DataProviderRepository : IReadOnlyRepository
    {
        private readonly IDbConnection _connection;
        private const string CacheIp = "127.0.0.1:6379";
        private static readonly ILog Log = LogManager.GetLogger<DataProviderRepository>();

        public DataProviderRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TItem> GetAll<TItem>(Func<TItem, bool> predicate) where TItem : class
        {
            try
            {
                using (var manager = new BasicRedisClientManager(CacheIp))
                using (var client = manager.GetClient())
                {
                    return predicate != null
                        ? client.GetTypedClient<TItem>().GetAll().Where(predicate)
                        : client.GetTypedClient<TItem>().GetAll();
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
                return _connection.Query<TItem>(sql, param);
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