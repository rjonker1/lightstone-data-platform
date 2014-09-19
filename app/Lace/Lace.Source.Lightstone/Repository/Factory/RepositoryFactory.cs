using System.Data;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository.ForModel;
using ServiceStack.Redis;

namespace Lace.Source.Lightstone.Repository.Factory
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

        public IReadOnlyRepository<Band> BandRepository()
        {
            return new BandsRepository(_connection,_redisClient);
        }

        public IReadOnlyRepository<Car> CarRepository()
        {
            return new CarRepository(_connection, _redisClient);
        }

        public IReadOnlyRepository<CarInfo> CarInfoRepository()
        {
            return new CarInfoRepository(_connection, _redisClient);
        }

        public IReadOnlyRepository<CarInfo> Vin12CarInfoRepository()
        {
            return new Vin12CarInfoRepository(_connection, _redisClient);
        }

        public IReadOnlyRepository<CarType> CarTypeRepository()
        {
            return new CarTypeRepository(_connection, _redisClient);
        }

        public IReadOnlyRepository<CarVendor> CarVendorRepository()
        {
            return new CarVendorRepository(_connection,_redisClient);
        }

        public IReadOnlyRepository<Make> MakeRepository()
        {
            return new MakeRepository(_connection,_redisClient);
        }

        public IReadOnlyRepository<Metric> MetricRepository()
        {
            return new MetricRepository(_connection,_redisClient);
        }

        public IReadOnlyRepository<Municipality> MuncipalityRepository()
        {
            return new MunicipalityRepository(_connection,_redisClient);
        }

        public IReadOnlyRepository<Sale> SaleRepository()
        {
            return new SaleRepository(_connection,_redisClient);
        }

        public IReadOnlyRepository<Statistic> StatisticRepository()
        {
            return new StatisticsRepository(_connection, _redisClient);
        }
    }
}
