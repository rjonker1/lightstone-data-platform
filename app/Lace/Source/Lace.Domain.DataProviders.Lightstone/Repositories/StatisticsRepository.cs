using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Shared.DataProvider.Models;
using ServiceStack.Common.Extensions;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Domain.DataProviders.Lightstone.Repositories
{
    public class StatisticsRepository : IReadOnlyRepository<Statistic>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        public StatisticsRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Statistic> Get(string sql, object param, string cacheKey)
        {
            using (_cacheClient)
            {
                var key = string.Format(cacheKey, param);
                var cachedStatistics = _cacheClient.As<Statistic>();
                var response = cachedStatistics.Lists[key];

                if (response.DoesExistInTheCache())
                    return response.ToList();

                IEnumerable<Statistic> dbResponse =
                    _connection.Query<Statistic>(sql, param).ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, key, DateTime.UtcNow.AddDays(1));

                return dbResponse;
            }
        }

        public IEnumerable<Statistic> GetAll(string sql, string cacheKey)
        {
            using (_cacheClient)
            {
                var cachedStatistics = _cacheClient.As<Statistic>();
                var response = cachedStatistics.Lists[cacheKey];

                return response.DoesExistInTheCache() ? response.ToList() : new List<Statistic>();
            }
        }
    }
}
