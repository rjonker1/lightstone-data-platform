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
    public class BandsRepository : IReadOnlyRepository<Band>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string BandsKey = "urn:Auto_Carstats:Bands";

        public BandsRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }
        

        public IEnumerable<Band> Get(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Band> GetAll(string sql)
        {
            using (_cacheClient)
            {
                var cacheBands = _cacheClient.As<Band>();
                var response = cacheBands.Lists[BandsKey];

                if (response.DoesExistInTheCache())
                    return response;

                var dbResponse = _connection
                    .Query<Band>(sql)
                    .ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, BandsKey, DateTime.UtcNow.AddDays(1));

                return dbResponse;
            }
        }
    }
}
