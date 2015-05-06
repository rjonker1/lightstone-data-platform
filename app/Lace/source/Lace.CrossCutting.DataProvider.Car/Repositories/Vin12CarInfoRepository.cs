using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.Shared.DataProvider.Models;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.CrossCutting.DataProvider.Car.Repositories
{
    public class Vin12CarInfoRepository : IReadOnlyCarRepository<CarInformation>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        public Vin12CarInfoRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<CarInformation> Get(string sql, object param, string cacheKey)
        {
            using (_connection)
            {
                using (_cacheClient)
                {
                    var key = string.Format(cacheKey, param);
                    var cachedCar = _cacheClient.As<CarInformation>();
                    var response = cachedCar.Lists[key];

                    if (response != null && response.Any())
                        return response;

                    var dbResponse =
                        _connection.Query<CarInformation>(sql, param)
                            .ToList();

                    dbResponse.ForEach(f => response.Add(f));
                    _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(1));
                    return dbResponse;
                }
            }
        }

        public IEnumerable<CarInformation> GetAll(string sql, string cacheKey)
        {
            using (_connection)
            {
                using (_cacheClient)
                {
                    var cachedCar = _cacheClient.As<CarInformation>();
                    var response = cachedCar.Lists[cacheKey];
                    return response != null && response.Any() ? response.ToList() : new List<CarInformation>();
                }
            }
        }
    }
}
