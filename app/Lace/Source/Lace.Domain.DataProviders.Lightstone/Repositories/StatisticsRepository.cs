using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.SqlStatements;
using Lace.Domain.DataProviders.Lightstone.Services;
using ServiceStack.Common.Extensions;
using ServiceStack.Redis;

namespace Lace.Domain.DataProviders.Lightstone.Repositories
{
    public class StatisticsRepository : IReadOnlyRepository<Statistic>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string StatisticsKey = "urn:Auto_Carstats:Statistics:{0}:{1}:{2}";

        public StatisticsRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Statistic> FindAllWithRequest(IProvideCarInformationForRequest request)
        {
            using (_connection)
            using (_cacheClient)
            {
                var key = string.Format(StatisticsKey, request.CarId, request.MakeId, request.Year);
                var cachedStatistics = _cacheClient.As<Statistic>();
                var response = cachedStatistics.Lists[key];

                if (response != null && response.Any())
                    return response;

                IEnumerable<Statistic> dbResponse =
                    _connection.Query<Statistic>(SelectStatements.GetStatistics,
                        new
                        {
                            @CarId = request.CarId,
                            @MakeId = request.MakeId,
                            @YearId = request.Year

                        }).ToList();

                dbResponse.ForEach(f => response.Add(f));
                _cacheClient.Add(key, response, DateTime.UtcNow.AddHours(1));
                return dbResponse;
            }
        }

        public IEnumerable<Statistic> GetAll()
        {
            throw new NotImplementedException();
        }

        private static readonly Func<MetricTypes[],string> ConcatenateMetrics = (metricTypes) =>
        {
            var metrics = String.Join(", ", metricTypes.Select(s => s.ToString()));
            return metrics;
        };


        public IEnumerable<Statistic> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes)
        {
            using (_connection)
            using (_cacheClient)
            {
                var key = string.Format(StatisticsKey, makeId, 0, 0);
                var cachedMakeStats = _cacheClient.As<Statistic>();
                var response = cachedMakeStats.Lists[key];

                if (response != null && response.Any())
                    return response;

                var dbResponse =
                    _connection.Query<Statistic>(SelectStatements.GetStatisticsByMake,
                        new { @Metrics = ConcatenateMetrics(metricTypes), @MakeId = makeId }).ToList();
                dbResponse.ForEach(f => response.Add(f));
                _cacheClient.Add(key, response, DateTime.UtcNow.AddHours(1));
                return response;
            }
        }


        public IEnumerable<Statistic> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Statistic> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Statistic> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }


    }
}
