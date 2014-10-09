using System.Data;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Core.Models;
using ServiceStack.Redis;

namespace Lace.CrossCutting.DataProvider.Car.Repositories.Factory
{
    public class CarRepositoryFactory : ISetupCarRepository
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _redisClient;

        public CarRepositoryFactory(IDbConnection connection, IRedisClient redisClient)
        {
            _connection = connection;
            _redisClient = redisClient;
        }

        public IReadOnlyCarRepository<CarInfo> CarInfoRepository()
        {
            return new CarInfoRepository(_connection, _redisClient);
        }

        public IReadOnlyCarRepository<CarInfo> Vin12CarInfoRepository()
        {
            return new Vin12CarInfoRepository(_connection, _redisClient);
        }
    }
}
