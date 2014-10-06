using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Providers;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.SqlStatements;
using Lace.Domain.DataProviders.Lightstone.Services;
using ServiceStack.Redis;

namespace Lace.Domain.DataProviders.Lightstone.Repositories
{
    public class CarTypeRepository : IReadOnlyRepository<CarType>
    {

        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string CarTypeKey = "urn:Auto_Carstats:CarType:{0}";

        public CarTypeRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<CarType> FindAllWithRequest(IProvideCarInformationForRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarType> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarType> FindByMake(int makeId)
        {
            using (_connection)
            using (_cacheClient)
            {
                var key = string.Format(CarTypeKey, makeId);
                var cachedCarTypes = _cacheClient.As<CarType>();
                var response = cachedCarTypes.Lists[key];

                if (response != null && response.Any())
                    return response;

                var dbResponse = _connection
                    .Query<CarType>(SelectStatements.GetCarTypesByMake, new {@MakeId = makeId})
                    .ToList();

                dbResponse.ForEach(f => response.Add(f));
                _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(1));
                return dbResponse;

            }
        }

        public IEnumerable<CarType> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarType> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarType> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }
    }
}
