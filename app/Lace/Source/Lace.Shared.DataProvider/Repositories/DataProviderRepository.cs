using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Shared.DataProvider.Repositories
{
    public class DataProviderRepository : IReadOnlyRepository
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        public DataProviderRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IQueryable<TItem> GetAll<TItem>(string sql, string cacheKey) where TItem : class
        {
            using (_cacheClient)
            {
                //var cachedStatistics = _cacheClient.As<TItem>();
                //var response = cachedStatistics.Lists[cacheKey];
                var response = _cacheClient.Get<IQueryable<TItem>>(cacheKey);
                return response.DoesExistInTheCache() ? response : new List<TItem>().AsQueryable();
            }
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param, string cacheKey) where TItem : class
        {
            using (_cacheClient)
            {
                var key = string.Format(cacheKey, param);
                //var cachedStatistics = _cacheClient.As<TItem>();
                var response = _cacheClient.Get<IQueryable<TItem>>(cacheKey);
                //var response = cachedStatistics.Lists[key];

                if (response.DoesExistInTheCache())
                    return response;

                var dbResponse =
                    _connection.Query<TItem>(sql, param);

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse.AsQueryable();

                dbResponse.ToList().ForEach(f => response.ToList().Add(f));
                dbResponse.AddItemsToCache(_cacheClient, key, DateTime.UtcNow.AddDays(2));

                return dbResponse.AsQueryable();
            }
        }

        public TItem Item<TItem>(string sql, object param, string cacheKey) where TItem : class
        {
            using (_cacheClient)
            {
                //var key = string.Format(cacheKey, param);
                //var cachedStatistics = _cacheClient.As<TItem>();
                //var response = cachedStatistics.Lists[key];
                var key = string.Format(cacheKey, param);
                var response = _cacheClient.Get<IQueryable<TItem>>(cacheKey);

                if (response.DoesExistInTheCache())
                    return response.FirstOrDefault();

                var dbResponse =
                    _connection.Query<TItem>(sql, param).FirstOrDefault();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                response.ToList().Add(dbResponse);
                _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(2));

                return dbResponse;
            }
        }
    }
}
