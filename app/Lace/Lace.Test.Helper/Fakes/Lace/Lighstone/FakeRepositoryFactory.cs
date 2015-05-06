using System;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Repositories;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Factory;
using Lace.Shared.DataProvider.Models;
using CarInformation = Lace.CrossCutting.DataProvider.Car.Core.Models.CarInformation;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{

    public class FakeCarRepositioryFactory : ISetupCarRepository
    {
        private readonly string _vin;
        public FakeCarRepositioryFactory(string vin)
        {
            _vin = vin;
        }

        public IReadOnlyCarRepository<CarInformation> CarInformationRepository()
        {
            return new FakeCarInfoRepository();
        }

        public IReadOnlyCarRepository<CarInformation> Vin12CarInformationRepository()
        {
            return new FakeVin12CarInfoRepository(_vin);
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
