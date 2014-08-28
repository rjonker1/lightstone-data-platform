using System.Collections.Generic;
using Lace.Request;
using Lace.Source.Lightstone.DataObjects;
using Lace.Source.Lightstone.Models;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;

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

    }
}
