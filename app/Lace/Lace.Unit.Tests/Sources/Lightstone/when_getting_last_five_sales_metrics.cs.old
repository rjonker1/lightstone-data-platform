using System.Linq;
using Lace.Models.Lightstone.Dto;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Metrics.Specifics;
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

            _metric = new LastFiveSalesMetric(sales,muncipalities);
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
        public void lightstone_last_five_sales_for_none_licensing_district_must_be_valid()
        {
            var none = _metric.MetricResult.FirstOrDefault(w => w.LicensingDistrict == "None");
            none.SalesDate.ShouldEqual("2013-10-25");
            none.SalesPrice.ShouldEqual("R 99 990,00");
        }

        [Observation]
        public void lightstone_last_five_sales_for_cape_town_licensing_district_must_be_valid()
        {
            var capeTown = _metric.MetricResult.FirstOrDefault(w => w.LicensingDistrict == "CITY OF CAPE TOWN");
            capeTown.SalesDate.ShouldEqual("2013-10-23");
            capeTown.SalesPrice.ShouldEqual("R 104 995,00");
        }

        [Observation]
        public void lightstone_last_five_sales_for_tshwane_licensing_district_must_be_valid()
        {
            var tshwane = _metric.MetricResult.FirstOrDefault(w => w.LicensingDistrict == "CITY OF TSHWANE");
            tshwane.SalesDate.ShouldEqual("2013-10-07");
            tshwane.SalesPrice.ShouldEqual("R 105 950,00");
        }

        [Observation]
        public void lightstone_last_five_sales_for_ethekwini_licensing_district_must_be_valid()
        {
            var ethekwini = _metric.MetricResult.FirstOrDefault(w => w.LicensingDistrict == "ETHEKWINI");
            ethekwini.SalesDate.ShouldEqual("2013-10-01");
            ethekwini.SalesPrice.ShouldEqual("R 101 000,01");
        }

        [Observation]
        public void lightstone_last_five_sales_for_hibiscus_coast_licensing_district_must_be_valid()
        {
            var hibiscus = _metric.MetricResult.FirstOrDefault(w => w.LicensingDistrict == "HIBISCUS COAST");
            hibiscus.SalesDate.ShouldEqual("2013-09-30");
            hibiscus.SalesPrice.ShouldEqual("R 97 000,00");
        }
    }
}
