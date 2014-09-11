using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository.Infrastructure;
using Lace.Source.Lightstone.Repository.Sql;
using ServiceStack.Redis;

namespace Lace.Source.Lightstone.Repository.ForModel
{
    public class SaleRepository : IReadOnlyRepository<Sale>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string SaleKey = "urn:Auto_Carstats:Sale:{0}:{1}";

        public SaleRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Sale> FindAllWithRequest(ILaceRequestCarInformation request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> FindByCarIdAndYear(int? carId, int year)
        {
            if (carId == null) return new List<Sale>();

            using (_connection)
            using (_cacheClient)
            {
                var key = string.Format(SaleKey, carId, year);
                var cachedSale = _cacheClient.As<Sale>();
                var response = cachedSale.Lists[key];


                if (response != null && response.Any())
                    return response;

                var dbResponse = _connection
                    .Query<Sale>(SelectStatements.GetTopFiveSalesForCarIdAndYear, new {@CarId = carId, @YearId = year})
                    .ToList();

                dbResponse.ForEach(f => response.Add(f));
                _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }
        }

        public IEnumerable<Sale> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }
    }
}
