using System.Data;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Repositories;
using ServiceStack.Redis;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Factory
{
    public class RepositoryFactory : ISetupRepository
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _redisClient;

        public RepositoryFactory(IDbConnection connection, IRedisClient redisClient)
        {
            _connection = connection;
            _redisClient = redisClient;
        }

        public Core.IReadOnlyRepository<Band> BandRepository()
        {
            return new BandsRepository(_connection,_redisClient);
        }

        public Core.IReadOnlyRepository<Car> CarRepository()
        {
            return new CarRepository(_connection, _redisClient);
        }

        public Core.IReadOnlyRepository<CarType> CarTypeRepository()
        {
            return new CarTypeRepository(_connection, _redisClient);
        }

        public Core.IReadOnlyRepository<CarVendor> CarVendorRepository()
        {
            return new CarVendorRepository(_connection,_redisClient);
        }

        public Core.IReadOnlyRepository<Make> MakeRepository()
        {
            return new MakeRepository(_connection,_redisClient);
        }

        public Core.IReadOnlyRepository<Metric> MetricRepository()
        {
            return new MetricRepository(_connection,_redisClient);
        }

        public Core.IReadOnlyRepository<Municipality> MuncipalityRepository()
        {
            return new MunicipalityRepository(_connection,_redisClient);
        }

        public Core.IReadOnlyRepository<Sale> SaleRepository()
        {
            return new SaleRepository(_connection,_redisClient);
        }

        public Core.IReadOnlyRepository<Statistic> StatisticRepository()
        {
            return new StatisticsRepository(_connection, _redisClient);
        }
    }
}
