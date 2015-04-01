using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.SqlStatements;
using Lace.Domain.DataProviders.Lightstone.Services;
using ServiceStack.Redis;

namespace Lace.Domain.DataProviders.Lightstone.Repositories
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

        public IEnumerable<Sale> FindAllWithRequest(IHaveCarInformation request)
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

            //using (_connection)
            using (_cacheClient)
            {
                var key = string.Format(SaleKey, carId, year);
                var cachedSale = _cacheClient.As<Sale>();
                var response = cachedSale.Lists[key];


                if (response.DoesExistInTheCache())
                    return response;

                var dbResponse = _connection
                    .Query<Sale>(SelectStatements.GetTopFiveSalesForCarIdAndYear, new {@CarId = carId, @YearId = year})
                    .ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, key, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }
        }

        public IEnumerable<Sale> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }
    }
}
