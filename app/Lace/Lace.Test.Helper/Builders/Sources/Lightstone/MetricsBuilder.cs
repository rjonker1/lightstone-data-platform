using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Queries;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Models;


namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class MetricsBuilder
    {
        private static readonly IHaveCarInformation RequestForCarId107483 =
            LaceRequestCarInformationRequestBuilder.ForCarId_107483();

        public static IEnumerable<StatisticDto> GetStatistics()
        {
            var repository = new FakeStatisticsRepository();
            var getStatistics = new StatisticsQuery(repository);
            getStatistics.GetStatistics(RequestForCarId107483);
            return getStatistics.Statistics;
        }

        public static IEnumerable<Band> GetBands()
        {
            var repository = new FakeBandsRepository();
            var getBands = new BandQuery(repository);
            getBands.GetBands(RequestForCarId107483);
            return getBands.Bands;
        }

        public static IEnumerable<Metric> GetMetrics()
        {
            var repository = new FakeMetricRepository();
            var getMetrics = new MetricQuery(repository);
            getMetrics.GetMetrics(RequestForCarId107483);
            return getMetrics.Metrics;
        }


        public static IEnumerable<Municipality> GetMunicipalities()
        {
            var repository = new FakeMunicipalityRepository();
            var getMuncipality = new MuncipalityQuery(repository);
            getMuncipality.GetMunicipalities(RequestForCarId107483);
            return getMuncipality.Municipalities;
        }

        public static IEnumerable<Sale> GetSales()
        {
            var repository = new FakeSaleRepository();
            var getSales = new SaleQuery(repository);
            getSales.GetSales(RequestForCarId107483);
            return getSales.Sales;
        }

        public static IEnumerable<Make> GetMakes()
        {
            var repository = new FakeMakeRepository();
            var getMakes = new MakeQuery(repository);
            getMakes.GetMakes(RequestForCarId107483);
            return getMakes.Makes;
        }
      
    }
}
