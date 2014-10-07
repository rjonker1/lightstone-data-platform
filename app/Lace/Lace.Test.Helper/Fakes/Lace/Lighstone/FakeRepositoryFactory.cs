using System;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Factory;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeRepositoryFactory : ISetupRepository
    {
        public IReadOnlyRepository<Band> BandRepository()
        {
           return new FakeBandsRepository();
        }

        public IReadOnlyRepository<Car> CarRepository()
        {
            return new FakeCarRepository();
        }

        public IReadOnlyRepository<CarType> CarTypeRepository()
        {
            return  new FakeCarTypeRepository();
        }

        public IReadOnlyRepository<CarVendor> CarVendorRepository()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyRepository<CarInfo> CarInfoRepository()
        {
            return new FakeCarInfoRepository();
        }

        public IReadOnlyRepository<CarInfo> Vin12CarInfoRepository()
        {
            return new FakeVin12CarInfoRepository();
        }

        public IReadOnlyRepository<Make> MakeRepository()
        {
            return new FakeMakeRepository();
        }

        public IReadOnlyRepository<Metric> MetricRepository()
        {
            return new FakeMetricRepository();
        }

        public IReadOnlyRepository<Municipality> MuncipalityRepository()
        {
            return new FakeMunicipalityRepository();
        }

        public IReadOnlyRepository<Sale> SaleRepository()
        {
            return new FakeSaleRepository();
        }

        public IReadOnlyRepository<Statistic> StatisticRepository()
        {
            return new FakeStatisticsRepository();
        }
    }
}
