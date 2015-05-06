using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.DataProviders.RgtVin.Core.Contracts;
using Lace.Shared.DataProvider.Models;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Domain.DataProviders.RgtVin.Repositories
{
    public class VinRepository : IReadOnlyRepository<Vin>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;
        public VinRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }
        
        
        public IEnumerable<Vin> Get(string sql, object param, string cacheKey)
        {
            using (_cacheClient)
            {
                var key = string.Format(cacheKey, param);
                var cachedVins = _cacheClient.As<Vin>();
                var response = cachedVins.Lists[key];

                if (response.DoesExistInTheCache())
                    return response;

                var dbResponse =
                    _connection.Query<Vin>(sql, param).ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, key, DateTime.UtcNow.AddDays(1));

                return dbResponse;
            }
        }

        public IEnumerable<Vin> GetAll(string sql, string cacheKey)
        {
            using (_cacheClient)
            {
                var cachedVins = _cacheClient.As<Vin>();
                var response = cachedVins.Lists[cacheKey];
                return response.DoesExistInTheCache() ? response.ToList() : new List<Vin>();
            }
        }
    }
}
