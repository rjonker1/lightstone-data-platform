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
    public class CarRepository : IReadOnlyRepository<Car>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string CarKey = "urn:Auto_Carstats:Car:{0}:{1}";

        public CarRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Car> FindAllWithRequest(IProvideCarInformationForRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAll()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Car> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> FindByCarIdAndYear(int? carId, int year)
        {
            if (carId == null) return new List<Car>();

            using (_connection)
            {
                using (_cacheClient)
                {
                    var key = string.Format(CarKey, carId, year);
                    var cachedCar = _cacheClient.As<Car>();
                    var response = cachedCar.Lists[key];

                    if (response != null && response.Any())
                        return response;

                    var dbResponse =
                        _connection.Query<Car>(SelectStatements.GetCarById, new { @CarId = carId }).ToList();

                    dbResponse.ForEach(f => response.Add(f));
                    _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(1));
                    return dbResponse;
                }
            }
        }

        public IEnumerable<Car> FindByVin(string vinNumber)
        {
            using (_connection)
            {
                using (_cacheClient)
                {
                    var key = string.Format(CarKey, vinNumber, 0);
                    var cachedCar = _cacheClient.As<Car>();
                    var response = cachedCar.Lists[key];

                    if (response != null && response.Any())
                        return response;

                    var dbResponse =
                        _connection.Query<Car>(SelectStatements.GetCarByVin, new { @Vin = vinNumber }).ToList();

                    dbResponse.ForEach(f => response.Add(f));
                    _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(1));
                    return dbResponse;
                }
            }
        }

        public IEnumerable<Car> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }
    }
}
