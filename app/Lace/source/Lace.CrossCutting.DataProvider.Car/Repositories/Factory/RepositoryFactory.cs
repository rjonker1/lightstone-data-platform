using System.Data;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Shared.DataProvider.Models;
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

        public IReadOnlyCarRepository<CarInformation> CarInformationRepository()
        {
            return new CarInformationRepository(_connection, _redisClient);
        }

        public IReadOnlyCarRepository<CarInformation> Vin12CarInformationRepository()
        {
            return new Vin12CarInfoRepository(_connection, _redisClient);
        }

        public void Dispose()
        {
            if (_connection != null) _connection.Dispose();
        }
    }
}
