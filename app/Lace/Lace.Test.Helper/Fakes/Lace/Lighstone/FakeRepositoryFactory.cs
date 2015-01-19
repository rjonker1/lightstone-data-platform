using System;
using Lace.CrossCutting.DataProviderCommandSource.Car.Core.Contracts;
using Lace.CrossCutting.DataProviderCommandSource.Car.Core.Models;
using Lace.CrossCutting.DataProviderCommandSource.Car.Repositories;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Factory;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{

    public class FakeCarRepositioryFactory : ISetupCarRepository
    {
        public IReadOnlyCarRepository<CarInfo> CarInfoRepository()
        {
            return new FakeCarInfoRepository();
        }

        public IReadOnlyCarRepository<CarInfo> Vin12CarInfoRepository()
        {
            return new FakeVin12CarInfoRepository();
        }

        public void Dispose()
        {

        }
    }

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

        public void Dispose()
        {
            
        }
    }
}
