using System.Collections.Generic;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.UnitOfWork;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;


namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class MetricsBuilder
    {
        private static readonly IHaveCarInformation RequestForCarId107483 =
            LaceRequestCarInformationRequestBuilder.ForCarId_107483();

        public static IEnumerable<Statistic> GetStatistics()
        {
            var repository = new FakeStatisticsRepository();
            var getStatistics = new StatisticsUnitOfWork(repository);
            getStatistics.GetStatistics(RequestForCarId107483);
            return getStatistics.Statistics;
        }

        public static IEnumerable<Band> GetBands()
        {
            var repository = new FakeBandsRepository();
            var getBands = new BandUnitOfWork(repository);
            getBands.GetBands(RequestForCarId107483);
            return getBands.Bands;
        }

        public static IEnumerable<Metric> GetMetrics()
        {
            var repository = new FakeMetricRepository();
            var getMetrics = new MetricUnitOfWork(repository);
            getMetrics.GetMetrics(RequestForCarId107483);
            return getMetrics.Metrics;
        }


        public static IEnumerable<Municipality> GetMunicipalities()
        {
            var repository = new FakeMunicipalityRepository();
            var getMuncipality = new MuncipalityUnitOfWork(repository);
            getMuncipality.GetMunicipalities(RequestForCarId107483);
            return getMuncipality.Municipalities;
        }

        public static IEnumerable<Sale> GetSales()
        {
            var repository = new FakeSaleRepository();
            var getSales = new SaleUnitOfWork(repository);
            getSales.GetSales(RequestForCarId107483);
            return getSales.Sales;
        }

        public static IEnumerable<Make> GetMakes()
        {
            var repository = new FakeMakeRepository();
            var getMakes = new MakeUnitOfWork(repository);
            getMakes.GetMakes(RequestForCarId107483);
            return getMakes.Makes;
        }
      
    }
}
