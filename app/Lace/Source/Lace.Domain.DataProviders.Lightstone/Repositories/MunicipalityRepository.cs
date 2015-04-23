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
    public class MunicipalityRepository : IReadOnlyRepository<Municipality>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string MunicipalityKey = "urn:Auto_Carstats:Municipality";


        public MunicipalityRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Municipality> Get(string sql, object param)
        {
           throw new NotImplementedException();
        }

        public IEnumerable<Municipality> GetAll(string sql)
        {
            using (_cacheClient)
            {
                var cacheMuncipalities = _cacheClient.As<Municipality>();
                var response = cacheMuncipalities.Lists[MunicipalityKey];

                if (response.DoesExistInTheCache())
                    return response;

                var dbResponse = _connection
                    .Query<Municipality>(sql)
                    .ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, MunicipalityKey, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }
        }
    }
}

