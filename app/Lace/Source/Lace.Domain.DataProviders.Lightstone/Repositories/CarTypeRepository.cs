using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
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

        public IEnumerable<CarType> FindAllWithRequest(IHaveCarInformation request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarType> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarType> FindByMake(int makeId)
        {
            //using (_connection)
            using (_cacheClient)
            {
                var key = string.Format(CarTypeKey, makeId);
                var cachedCarTypes = _cacheClient.As<CarType>();
                var response = cachedCarTypes.Lists[key];

                if (response.DoesExistInTheCache())
                    return response;

                var dbResponse = _connection
                    .Query<CarType>(SelectStatements.GetCarTypesByMake, new {@MakeId = makeId})
                    .ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, key, DateTime.UtcNow.AddDays(1));

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
