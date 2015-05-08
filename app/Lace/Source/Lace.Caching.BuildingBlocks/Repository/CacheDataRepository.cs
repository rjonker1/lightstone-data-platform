using System;
using System.Collections.Generic;
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
        private readonly IRedisClient _cacheClient;
        private readonly ILog _log;


        public CacheDataRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
            _log = LogManager.GetLogger(GetType());
        }

        public void AddItems<TItem>(string sql, string cacheKey) where TItem : class
        {
            try
            {
                using (_cacheClient)
                {
                    var cachedItem = _cacheClient.As<TItem>();
                    var existing = cachedItem.Lists[cacheKey];

                    if (existing != null)
                    {
                        existing.Clear();
                        existing.RemoveAll();
                    }

                    var dbResponse =
                        _connection.Query<TItem>(sql)
                            .ToList();

                    _log.InfoFormat("Trying to add {0} to the cache. Number of rows {1}", typeof (TItem).FullName, dbResponse.Count);

                    //_cacheClient.StoreAll(_connection.Query<TItem>(sql));

                    _connection.Query<TItem>(sql).ToList().ForEach(f => existing.Add(f));
                    _cacheClient.Add(cacheKey, existing, DateTime.UtcNow.AddDays(2));

                    _log.InfoFormat("Added {0} to the cache. Number of rows {1}", typeof (TItem).FullName, dbResponse.Count);
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Cannot Add Items to Cache because of {0}", ex, ex.Message);
            }
        }

        public IEnumerable<TItem> Get<TItem>(string cacheKey) where TItem : class
        {
            using (_cacheClient)
            {
                var cachedItem = _cacheClient.As<TItem>();
                var existing = cachedItem.Lists[cacheKey];
                return existing.DoesExistInTheCache() ? existing.ToList() : new List<TItem>();
            }
        }

        public void AddItem<TItem>(string sql, object param, string cacheKey) where TItem : class
        {
            try
            {
                using (_cacheClient)
                {
                    var cachedItem = _cacheClient.As<TItem>();
                    var existing = cachedItem.Lists[cacheKey];

                    if (existing != null)
                    {
                        existing.Clear();
                    }

                    var dbResponse =
                        _connection.Query<TItem>(sql, param)
                            .ToList();

                    _log.InfoFormat("Tring to add {0} to the cache. Number of rows {1}", typeof (TItem).FullName, dbResponse.Count);

                    dbResponse.ForEach(f => existing.Add(f));
                    _cacheClient.Add(cacheKey, existing, DateTime.UtcNow.AddDays(2));

                    _log.InfoFormat("Added {0} to the cache. Number of rows {1}", typeof (TItem).FullName, dbResponse.Count);
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Cannot Add Item to Cache because of {0}", ex, ex.Message);
            }

        }

        public void Clear<TItem>(string cacheKey) where TItem : class
        {
            try
            {
                using (_cacheClient)
                {
                    var cachedItem = _cacheClient.As<TItem>();
                    var existing = cachedItem.Lists[cacheKey];

                    if (!existing.DoesExistInTheCache())
                        return;

                    existing.Clear();
                    existing.RemoveAll();
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Cannot Clear Item from Cache because of {0}", ex,ex.Message);
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
