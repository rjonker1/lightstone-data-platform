using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.DataProviderCommandSource.Car.Core.Models;
using Lace.CrossCutting.DataProviderCommandSource.Car.Infrastructure.SqlStatements;
using Lace.CrossCutting.Infrastructure.Orm;
using ServiceStack.Redis;

namespace Lace.CrossCutting.DataProviderCommandSource.Car.Repositories
{
    public class CarInfoRepository : IReadOnlyCarRepository<CarInfo>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string CarKey = "urn:Auto_Carstats:CarInfo:{0}:{1}";

        public CarInfoRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<CarInfo> FindByCarIdAndYear(int? carId, int year)
        {
            //using (_connection)
            using (_cacheClient)
            {
                var key = string.Format(CarKey, carId, year);
                var cachedCar = _cacheClient.As<CarInfo>();
                var response = cachedCar.Lists[key];

                if (response != null && response.Any())
                    return response;

                var dbResponse =
                    _connection.Query<CarInfo>(SelectStatements.GetCarInformationById, new {@CarId = carId})
                        .ToList();

                dbResponse.ForEach(f => response.Add(f));
                _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }
        }

        public IEnumerable<CarInfo> FindByVin(string vinNumber)
        {
            //using (_connection)
            using (_cacheClient)
            {
                var key = string.Format(CarKey, vinNumber, 0);
                var cachedCar = _cacheClient.As<CarInfo>();
                var response = cachedCar.Lists[key];

                if (response != null && response.Any())
                    return response;

                var dbResponse =
                    _connection.Query<CarInfo>(SelectStatements.GetCarInformationByVin, new {@Vin = vinNumber})
                        .ToList();

                dbResponse.ForEach(f => response.Add(f));
                _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }

        }
    }
}
