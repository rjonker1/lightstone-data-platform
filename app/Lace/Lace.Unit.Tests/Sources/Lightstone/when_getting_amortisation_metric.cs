using System.Linq;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Domain.DataProviders.Lightstone.Services.Specifics;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Lace.Toolbox.Database.Base;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_amortisation_metric : Specification
    {
        private readonly IRetrieveATypeOfMetric<AmortisedValueModel> _metric;
        private readonly IHaveCarInformation _request;

        public when_getting_amortisation_metric()
        {
            _request = LaceRequestCarInformationRequestBuilder.ForCarId_107483();
            var stats = MetricsBuilder.GetStatistics();
           // var bands = MetricsBuilder.GetBands();

            _metric = new AmortisedValueMetric(_request, stats); //, bands
        }

        public override void Observe()
        {
            _metric.Get();
        }

        [Observation]
        public void lightstone_amortised_gauge_should_exist()
        {
            _metric.MetricResult.ShouldNotBeNull();
            _metric.MetricResult.Count.ShouldNotEqual(0);
        }

        [Observation]
        public void lightstone_amortised_gauge_year_0_should_be_valid()
        {
            var zeroGauge = _metric.MetricResult.FirstOrDefault(w => w.Year == "0");
            zeroGauge.ShouldNotBeNull();
            zeroGauge.Value.ShouldEqual(90600M);
        }

        [Observation]
        public void lightstone_amortised_gauge_year_1_should_be_valid()
        {
            var oneGauge = _metric.MetricResult.FirstOrDefault(w => w.Year == "1");
            oneGauge.ShouldNotBeNull();
            oneGauge.Value.ShouldEqual(79000M);
        }

        [Observation]
        public void lightstone_amortised_gauge_year_2_should_be_valid()
        {
            var twoGauge = _metric.MetricResult.FirstOrDefault(w => w.Year == "2");
            twoGauge.ShouldNotBeNull();
            twoGauge.Value.ShouldEqual(68000M);
        }

        //[Observation]
        //public void lightstone_amortised_gauge_year_3_should_be_valid()
        //{
        //    var threeGauge = _metric.MetricResult.FirstOrDefault(w => w.Year == "3");
        //    threeGauge.ShouldNotBeNull();
        //    threeGauge.Value.ShouldEqual(58300);
        //}
    }
}
