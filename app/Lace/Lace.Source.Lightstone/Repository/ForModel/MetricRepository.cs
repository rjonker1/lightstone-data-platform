using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository.Infrastructure;
using Lace.Source.Lightstone.Repository.Sql;
using ServiceStack.Redis;

namespace Lace.Source.Lightstone.Repository.ForModel
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
        
        public IEnumerable<Metric> FindAllWithRequest(IProvideCarInformationForRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Metric> GetAll()
        {
            using (_connection)
            {
                using (_cacheClient)
                {
                    var cacheMetric = _cacheClient.As<Metric>();
                    var response = cacheMetric.Lists[MetricKey];

                    if (response != null && response.Any())
                        return response;

                    var dbResponse = _connection
                        .Query<Metric>(SelectStatements.GetAllTheMetricTypes)
                        .ToList();

                    dbResponse.ForEach(f => response.Add(f));

                    _cacheClient.Add(MetricKey, response, DateTime.UtcNow.AddDays(1));
                    return dbResponse;
                }
            }
        }

        public IEnumerable<Metric> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Metric> FindByMakeAndMetricTypes(int makeId, Metrics.MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Metric> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Metric> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }
    }
}
