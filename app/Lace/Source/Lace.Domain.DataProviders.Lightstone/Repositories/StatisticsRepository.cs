using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using ServiceStack.Common.Extensions;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Domain.DataProviders.Lightstone.Repositories
{
    public class StatisticsRepository : IReadOnlyRepository<Statistic>
    {
        //SelectStatements.GetStatistics

        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string StatisticsKey = "urn:Auto_Carstats:Statistics:{0}:{1}:{2}";

        public StatisticsRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Statistic> Get(string sql, object param)
        {
            using (_cacheClient)
            {
                var key = string.Format(StatisticsKey, param);
                var cachedStatistics = _cacheClient.As<Statistic>();
                var response = cachedStatistics.Lists[key];

                if (response.DoesExistInTheCache())
                    return response;

                IEnumerable<Statistic> dbResponse =
                    _connection.Query<Statistic>(sql, param).ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, key, DateTime.UtcNow.AddDays(1));

                return dbResponse;
            }
        }

        public IEnumerable<Statistic> GetAll(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
