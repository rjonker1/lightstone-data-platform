using System.Collections.Generic;
using Lace.Request;
using Lace.Source.Lightstone.DataObjects;
using Lace.Source.Lightstone.Models;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using BandData = Lace.Source.Lightstone.DataObjects.BandData;
using MetricData = Lace.Source.Lightstone.DataObjects.MetricData;
using StatisticsData = Lace.Source.Lightstone.DataObjects.StatisticsData;

namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class MetricsBuilder
    {
        private static readonly ILaceRequestCarInformation RequestForCarId107483 =
            LaceRequestCarInformationRequestBuilder.ForCarId_107483();

        public static IEnumerable<Statistic> GetStatistics()
        {
            var repository = new FakeStatisticsRepository();
            var getStatistics = new StatisticsData(repository);
            getStatistics.GetStatistics(RequestForCarId107483);
            return getStatistics.Statistics;
        }

        public static IEnumerable<Band> GetBands()
        {
            var repository = new FakeBandsRepository();
            var getBands = new BandData(repository);
            getBands.GetBands(RequestForCarId107483);
            return getBands.Bands;
        }

        public static IEnumerable<Metric> GetMetrics()
        {
            var repository = new FakeMetricRepository();
            var getMetrics = new MetricData(repository);
            getMetrics.GetMetrics(RequestForCarId107483);
            return getMetrics.Metrics;
        }


        public static IEnumerable<Municipality> GetMunicipalities()
        {
            var repository = new FakeMunicipalityRepository();
            var getMuncipality = new MuncipalityData(repository);
            getMuncipality.GetMunicipalities(RequestForCarId107483);
            return getMuncipality.Municipalities;
        }

        public static IEnumerable<Sale> GetSales()
        {
            var repository = new FakeSaleRepository();
            var getSales = new SaleData(repository);
            getSales.GetSales(RequestForCarId107483);
            return getSales.Sales;
        }

        public static IEnumerable<Make> GetMakes()
        {
            var repository = new FakeMakeRepository();
            var getMakes = new MakeData(repository);
            getMakes.GetMakes(RequestForCarId107483);
            return getMakes.Makes;
        }

    }
}
