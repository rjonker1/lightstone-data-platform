using System;
using System.Linq;
using System.Text.RegularExpressions;
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
            Regex.Replace(_metric.MetricResult.FirstOrDefault().RetailEstimatedHigh, @"\s+", "").ShouldEqual("R99700,00");
        }

        [Observation]
        public void lightstone_retail_estimated_low_should_be_valid()
        {
            Regex.Replace(_metric.MetricResult.FirstOrDefault().RetailEstimatedLow, @"\s+", "").ShouldEqual("R81500,00");
        }

        [Observation]
        public void lightstone_retail_estimated_value_should_be_valid()
        {
            Regex.Replace(_metric.MetricResult.FirstOrDefault().RetailEstimatedValue, @"\s+", "").ShouldEqual("R90600,00");
        }

        [Observation]
        public void lightstone_trade_estimated_value_should_be_valid()
        {
            Regex.Replace(_metric.MetricResult.FirstOrDefault().TradeEstimatedValue, @"\s+", "").ShouldEqual("R83300,00");
        }

        [Observation]
        public void lightstone_trade_estimated_value_low_should_be_valid()
        {
            Regex.Replace(_metric.MetricResult.FirstOrDefault().TradeEstimatedLow, @"\s+", "").ShouldEqual("R75000,00");
        }

        [Observation]
        public void lightstone_trade_estimated_value_high_should_be_valid()
        {
            Regex.Replace(_metric.MetricResult.FirstOrDefault().TradeEstimatedHigh, @"\s+", "").ShouldEqual("R89140,00");
        }
    }
}
