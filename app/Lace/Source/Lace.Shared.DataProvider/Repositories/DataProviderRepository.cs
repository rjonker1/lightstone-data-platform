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
            try
            {
                using (_cacheClient)
                {
                    var cachedItem = _cacheClient.As<TItem>();
                    var response = cachedItem.Lists[cacheKey];
                    return response != null && response.Any() ? response.AsQueryable() : new List<TItem>().AsQueryable();
                }
            }
            catch 
            {

            }
            return new List<TItem>().AsQueryable();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param, string cacheKey) where TItem : class
        {
            using (_cacheClient)
            {
                var key = string.Format(cacheKey, param);
                var cachedItem = _cacheClient.As<TItem>();
                var response = cachedItem.Lists[key];

                if (response.DoesExistInTheCache())
                    return response.AsQueryable();

                var dbResponse =
                    _connection.Query<TItem>(sql, param);

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse.AsQueryable();

                dbResponse.ToList().ForEach(f => response.ToList().Add(f));
                _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(2));

                return dbResponse.AsQueryable();
            }
        }

        //public TItem Item<TItem>(string sql, object param, string cacheKey) where TItem : class
        //{
        //    using (_cacheClient)
        //    {
        //        //var key = string.Format(cacheKey, param);
        //        //var cachedStatistics = _cacheClient.As<TItem>();
        //        //var response = cachedStatistics.Lists[key];
        //        var key = string.Format(cacheKey, param);
        //        var response = _cacheClient.Get<IQueryable<TItem>>(cacheKey);

        //        if (response.DoesExistInTheCache())
        //            return response.FirstOrDefault();

        //        var dbResponse =
        //            _connection.Query<TItem>(sql, param).FirstOrDefault();

        //        if (!response.CanAddItemsToCache().HasValue)
        //            return dbResponse;

        //        response.ToList().Add(dbResponse);
        //        _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(1));

        //        return dbResponse;
        //    }
        //}
    }
}
