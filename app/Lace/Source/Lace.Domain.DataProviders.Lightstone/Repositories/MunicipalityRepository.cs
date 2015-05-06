using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Shared.DataProvider.Models;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Domain.DataProviders.Lightstone.Repositories
{
    public class MunicipalityRepository : IReadOnlyRepository<Municipality>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        public MunicipalityRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Municipality> Get(string sql, object param, string cacheKey)
        {
           throw new NotImplementedException();
        }

        public IEnumerable<Municipality> GetAll(string sql, string cacheKey)
        {
            using (_cacheClient)
            {
                var cacheMuncipalities = _cacheClient.As<Municipality>();
                var response = cacheMuncipalities.Lists[cacheKey];

                if (response.DoesExistInTheCache())
                    return response;

                var dbResponse = _connection
                    .Query<Municipality>(sql)
                    .ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, cacheKey, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }
        }
    }
}

