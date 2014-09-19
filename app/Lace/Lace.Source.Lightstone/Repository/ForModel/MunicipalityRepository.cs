using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository.Infrastructure;
using Lace.Source.Lightstone.Repository.Sql;
using ServiceStack.Redis;

namespace Lace.Source.Lightstone.Repository.ForModel
{
    public class MunicipalityRepository : IReadOnlyRepository<Municipality>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string MunicipaliiesKey = "urn:Auto_Carstats:Municipality";


        public MunicipalityRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Municipality> FindAllWithRequest(Request.IProvideCarInformationForRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> GetAll()
        {
            using (_connection)
            using (_cacheClient)
            {
                var cacheMuncipalities = _cacheClient.As<Municipality>();
                var response = cacheMuncipalities.Lists[MunicipaliiesKey];

                if (response != null && response.Any())
                    return response;

                var dbResponse = _connection
                    .Query<Municipality>(SelectStatements.GetAllTheMuncipalities)
                    .ToList();

                dbResponse.ForEach(f => response.Add(f));

                _cacheClient.Add(MunicipaliiesKey, response, DateTime.UtcNow.AddDays(10));
                return dbResponse;
            }
        }

        public IEnumerable<Municipality> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> FindByMakeAndMetricTypes(int makeId, Metrics.MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }
    }
}
