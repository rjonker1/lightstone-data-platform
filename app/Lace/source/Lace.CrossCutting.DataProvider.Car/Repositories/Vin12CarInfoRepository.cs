using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Models;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.CrossCutting.DataProvider.Car.Repositories
{
    public class Vin12CarInfoRepository : IReadOnlyCarRepository<CarInformation>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string CarKey = "urn:Auto_Carstats:Vin12CarInformation:{0}";

        public Vin12CarInfoRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<CarInformation> Get(string sql, object param)
        {
            using (_connection)
            {
                using (_cacheClient)
                {
                    var key = string.Format(CarKey, param);
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

        public IEnumerable<CarInformation> GetAll(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
