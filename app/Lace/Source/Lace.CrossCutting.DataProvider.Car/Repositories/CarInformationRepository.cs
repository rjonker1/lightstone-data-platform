using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Shared.DataProvider.Models;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.CrossCutting.DataProvider.Car.Repositories
{
    public class CarInformationRepository : IReadOnlyCarRepository<CarInformation>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        public CarInformationRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<CarInformation> Get(string sql, object param, string cacheKey)
        {
            using (_cacheClient)
            {
                var key = string.Format(cacheKey, param);
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

        public IEnumerable<CarInformation> GetAll(string sql, string cacheKey)
        {
            using (_cacheClient)
            {
                var cachedCar = _cacheClient.As<CarInformation>();
                var response = cachedCar.Lists[cacheKey];
                return response.DoesExistInTheCache() ? response.ToList() : new List<CarInformation>();
            }
        }
    }
}
