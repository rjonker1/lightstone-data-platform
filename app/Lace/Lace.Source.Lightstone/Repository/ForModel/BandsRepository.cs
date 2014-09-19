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
        
        public IEnumerable<Band> FindAllWithRequest(IProvideCarInformationForRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Band> GetAll()
        {
            using (_connection)
            {
                using (_cacheClient)
                {
                    var cacheBands = _cacheClient.As<Band>();
                    var response = cacheBands.Lists[BandsKey];

                    if (response != null && response.Any())
                        return response;

                    var dbResponse = _connection
                        .Query<Band>(SelectStatements.GetAllTheBands)
                        .ToList();

                    dbResponse.ForEach(f => response.Add(f));

                    _cacheClient.Add(BandsKey, response, DateTime.UtcNow.AddDays(1));
                    return dbResponse;
                }
            }
        }

        public IEnumerable<Band> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Band> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Band> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Band> FindByMakeAndMetricTypes(int makeId, Metrics.MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }
    }
}
