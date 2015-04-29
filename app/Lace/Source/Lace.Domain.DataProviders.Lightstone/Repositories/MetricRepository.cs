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
    public class MetricRepository : IReadOnlyRepository<Metric>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string MetricKey = "urn:Auto_Carstats:Metric";

        public MetricRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Metric> Get(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Metric> GetAll(string sql)
        {
            using (_cacheClient)
            {
                var cacheMetric = _cacheClient.As<Metric>();
                var response = cacheMetric.Lists[MetricKey];

                if (response.DoesExistInTheCache())
                    return response;

                var dbResponse = _connection
                    .Query<Metric>(sql)
                    .ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, MetricKey, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }
        }
    }
}
