using System.Linq;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Domain.DataProviders.Lightstone.Services.Specifics;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_estimated_value_metrics : Specification
    {
        private readonly IRetrieveATypeOfMetric<EstimatedValueModel> _metric;

        public when_getting_estimated_value_metrics()
        {
            var request = LaceRequestCarInformationRequestBuilder.ForCarId_107483();
            var stats = MetricsBuilder.GetStatistics();

            _metric = new EstimatedValuesMetric(request, stats);
        }

        public override void Observe()
        {
            _metric.Get();
        }

        [Observation]
        public void lightstone_estimated_value_metric_result_should_exist()
        {
            _metric.MetricResult.ShouldNotBeNull();
            _metric.MetricResult.Count.ShouldNotEqual(0);
            _metric.MetricResult.Count.ShouldEqual(1);
        }

        [Observation]
        public void lightstone_retail_confidence_level_should_be_valid()
        {
            _metric.MetricResult.FirstOrDefault().RetailConfidenceLevel.ShouldEqual("Medium");
        }

        [Observation]
        public void lightstone_retail_estimated_high_should_be_valid()
        {
            _metric.MetricResult.FirstOrDefault().RetailEstimatedHigh.ShouldEqual("R 98 700,00");
        }

        [Observation]
        public void lightstone_retail_estimated_low_should_be_valid()
        {
            _metric.MetricResult.FirstOrDefault().RetailEstimatedLow.ShouldEqual("R 80 600,00");
        }

        [Observation]
        public void lightstone_retail_estimated_value_should_be_valid()
        {
            _metric.MetricResult.FirstOrDefault().RetailEstimatedValue.ShouldEqual("R 89 200,00");
        }

        [Observation]
        public void lightstone_trade_estimated_value_should_be_valid()
        {
            _metric.MetricResult.FirstOrDefault().RetailEstimatedValue.ShouldEqual("R 79 600,00");
        }

        [Observation]
        public void lightstone_trade_estimated_value_low_should_be_valid()
        {
            _metric.MetricResult.FirstOrDefault().RetailEstimatedValue.ShouldEqual("R 100,00");
        }

        [Observation]
        public void lightstone_trade_estimated_value_high_should_be_valid()
        {
            _metric.MetricResult.FirstOrDefault().RetailEstimatedValue.ShouldEqual("R 1000 000,00");
        }
    }
}
