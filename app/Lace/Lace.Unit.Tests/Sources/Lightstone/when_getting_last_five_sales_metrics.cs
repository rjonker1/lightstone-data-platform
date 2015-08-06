using System;
using System.Linq;
using System.Text.RegularExpressions;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Domain.DataProviders.Lightstone.Services.Specifics;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_last_five_sales_metrics : Specification
    {
        private readonly IRetrieveATypeOfMetric<SaleModel> _metric;

        public when_getting_last_five_sales_metrics()
        {
            var sales = MetricsBuilder.GetSales();
            var muncipalities = MetricsBuilder.GetMunicipalities();

            _metric = new LastFiveSalesMetric(sales, muncipalities);
        }


        public override void Observe()
        {
            _metric.Get();
        }

        [Observation]
        public void lightstone_last_five_sales_metric_result_should_exist()
        {
            _metric.MetricResult.ShouldNotBeNull();
            _metric.MetricResult.Count.ShouldNotEqual(0);
            _metric.MetricResult.Count.ShouldEqual(5);
        }

        [Observation]
        public void lightstone_last_five_sales_for_tlokwe_licensing_district_must_be_valid()
        {
            var tlokwe = _metric.MetricResult.FirstOrDefault(w => w.LicensingDistrict == "TLOKWE CITY COUNCIL");

            var expected = DateTime.Parse("2014-07-30");
            var actual = DateTime.Parse(tlokwe.SalesDate);

            actual.ShouldEqual(expected);
            Regex.Replace(tlokwe.SalesPrice, @"\s+", "").ShouldEqual("R98900,00");
        }

        [Observation]
        public void lightstone_last_five_sales_for_cape_town_licensing_district_must_be_valid()
        {
            var capeTown = _metric.MetricResult.FirstOrDefault(w => w.LicensingDistrict == "CITY OF CAPE TOWN");

            var expected = DateTime.Parse("2014-07-15");
            var actual = DateTime.Parse(capeTown.SalesDate);

            actual.ShouldEqual(expected);
            Regex.Replace(capeTown.SalesPrice, @"\s+", "").ShouldEqual("R100320,00");
        }

        [Observation]
        public void lightstone_last_five_sales_for_makhado_licensing_district_must_be_valid()
        {
            var makhado = _metric.MetricResult.FirstOrDefault(w => w.LicensingDistrict == "MAKHADO");

            var expected = DateTime.Parse("2014-07-22");
            var actual = DateTime.Parse(makhado.SalesDate);
            actual.ShouldEqual(expected);

            Regex.Replace(makhado.SalesPrice, @"\s+", "").ShouldEqual("R86800,00");
        }

        [Observation]
        public void lightstone_last_five_sales_for_ethekwini_licensing_district_must_be_valid()
        {
            var ethekwini = _metric.MetricResult.FirstOrDefault(w => w.LicensingDistrict == "ETHEKWINI");

            var expected = DateTime.Parse("2014-07-14");
            var actual = DateTime.Parse(ethekwini.SalesDate);

            actual.ShouldEqual(expected);
            Regex.Replace(ethekwini.SalesPrice, @"\s+", "").ShouldEqual("R96990,00");
        }

        [Observation]
        public void lightstone_last_five_sales_for_govan_mbeki_coast_licensing_district_must_be_valid()
        {
            var hibiscus = _metric.MetricResult.FirstOrDefault(w => w.LicensingDistrict == "GOVAN MBEKI");

            var expected = DateTime.Parse("2014-07-15");
            var actual = DateTime.Parse(hibiscus.SalesDate);

            actual.ShouldEqual(expected);
            Regex.Replace(hibiscus.SalesPrice, @"\s+", "").ShouldEqual("R93900,00");
        }
    }
}
