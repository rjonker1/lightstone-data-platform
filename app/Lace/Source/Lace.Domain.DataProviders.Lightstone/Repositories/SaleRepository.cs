using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Domain.DataProviders.Lightstone.Repositories
{
    public class SaleRepository : IReadOnlyRepository<Sale>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string SaleKey = "urn:Auto_Carstats:Sale:{0}";

        public SaleRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }


        public IEnumerable<Sale> Get(string sql, object param)
        {
            using (_cacheClient)
            {
                var key = string.Format(SaleKey, param);
                var cachedSale = _cacheClient.As<Sale>();
                var response = cachedSale.Lists[key];

                if (response.DoesExistInTheCache())
                    return response;

                 var dbResponse = _connection
                    .Query<Sale>(sql, param)
                    .ToList();

                 if (!response.CanAddItemsToCache().HasValue)
                     return dbResponse;

                 dbResponse.ForEach(f => response.Add(f));
                 dbResponse.AddItemsToCache(_cacheClient, key, DateTime.UtcNow.AddDays(1));
                 return dbResponse;
            }
        }

        public IEnumerable<Sale> GetAll(string sql)
        {
            using (_cacheClient)
            {
                var key = string.Format(SaleKey, sql);
                var cachedSale = _cacheClient.As<Sale>();
                var response = cachedSale.Lists[key];

                if (response.DoesExistInTheCache())
                    return response.ToList();

                var dbResponse = _connection
                    .Query<Sale>(sql)
                    .ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, key, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }
        }
    }
}
