using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.CrossCutting.DataProvider.Car.Repositories
{
    public class CarInformationRepository : IReadOnlyCarRepository<CarInformation>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string CarKey = "urn:Auto_Carstats:CarInformation:{0}";

        public CarInformationRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<CarInformation> Get(string sql, object param)
        {
            using (_cacheClient)
            {
                var key = string.Format(CarKey, param);
                var cachedCar = _cacheClient.As<CarInformation>();
                var response = cachedCar.Lists[key];

                if (response.DoesExistInTheCache())
                    return response.ToList();

                var dbResponse =
                    _connection.Query<CarInformation>(sql, param)
                        .ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, key, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }
        }

        public IEnumerable<CarInformation> GetAll(string sql)
        {
            using (_cacheClient)
            {
                var key = string.Format(CarKey, "all");
                var cachedCar = _cacheClient.As<CarInformation>();
                var response = cachedCar.Lists[key];

                if (response.DoesExistInTheCache())
                    return response.ToList();

                var dbResponse =
                    _connection.Query<CarInformation>(sql)
                        .ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, key, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }
        }
    }
}
