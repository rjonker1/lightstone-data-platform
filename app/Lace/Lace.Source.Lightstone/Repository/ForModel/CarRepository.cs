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
    public class CarRepository : IReadOnlyRepository<Car>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string CarKey = "urn:Car:{0}:{1}";
        private const string CarsKey = "urn:Cars";

        public CarRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Car> FindAllWithRequest(ILaceRequestCarInformation request)
        {
            return !string.IsNullOrEmpty(request.Vin) ? GetCarWithVin(request) : GetCarWithCarId(request);
        }

        private IEnumerable<Car> GetCarWithCarId(ILaceRequestCarInformation request)
        {
            if (request.CarId == null || request.Year == null) return new List<Car>();

            using (_connection)
            {
                using (_cacheClient)
                {
                    var key = string.Format(CarKey, request.CarId, request.Year);
                    var cachedCar = _cacheClient.As<Car>();
                    var response = cachedCar.Lists[key];

                    if (response != null && response.Any())
                        return response;

                    var dbResponse =
                        _connection.Query<Car>(SelectStatements.GetCarById, new {@CarId = request.CarId}).ToList();

                    dbResponse.ForEach(f => response.Add(f));
                    _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(1));
                    return dbResponse;

                }
            }
        }

        private IEnumerable<Car> GetCarWithVin(ILaceRequestCarInformation request)
        {
            using (_connection)
            {
                using (_cacheClient)
                {
                    var key = string.Format(CarKey, request.Vin, 0);
                    var cachedCar = _cacheClient.As<Car>();
                    var response = cachedCar.Lists[key];

                    if (response != null && response.Any())
                        return response;

                    var dbResponse =
                        _connection.Query<Car>(SelectStatements.GetCarByVin, new {@Vin = request.Vin}).ToList();

                    dbResponse.ForEach(f => response.Add(f));
                    _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(1));
                    return dbResponse;
                }
            }
        }

        public IEnumerable<Car> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
