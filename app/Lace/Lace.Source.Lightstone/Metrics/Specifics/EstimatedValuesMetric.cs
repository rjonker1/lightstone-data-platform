using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Models.Lightstone.Dto;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Metrics.Specifics
{
    public class EstimatedValuesMetric : IRetrieveATypeOfMetric<EstimatedValueModel>
    {
        public List<EstimatedValueModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        //private static readonly MetricTypes[] Metrics =
        //{
        //    MetricTypes.EstimatedPrice, MetricTypes.SalePriceLow,
        //    MetricTypes.SalePriceHigh, MetricTypes.Confidence
        //};

        private IList<Statistic> _gauges;
        private readonly ILaceRequestCarInformation _request;

        public EstimatedValuesMetric(ILaceRequestCarInformation request, IEnumerable<Statistic> statistics)
        {
            Statistics = statistics;
            _request = request;
            MetricResult = new List<EstimatedValueModel>();
        }

        public void Get()
        {
            _gauges = GetGauges();

            if (!_gauges.Any()) return;

            var estimatedPrice = _gauges.FirstOrDefault(w => w.Metric_ID == (int) MetricTypes.EstimatedPrice);
            var salePriceHigh = _gauges.FirstOrDefault(w => w.Metric_ID == (int) MetricTypes.SalePriceHigh);
            var salePriceLow = _gauges.FirstOrDefault(w => w.Metric_ID == (int) MetricTypes.SalePriceLow);
            var confidence = _gauges.FirstOrDefault(w => w.Metric_ID == (int) MetricTypes.Confidence);


            if (estimatedPrice == null || salePriceHigh == null || salePriceLow == null || confidence == null) return;

            MetricResult.Add(new EstimatedValueModel(
                estimatedPrice.MoneyValue.HasValue ? estimatedPrice.MoneyValue.Value.ToString("C") : "",
                salePriceLow.MoneyValue.HasValue ? salePriceLow.MoneyValue.Value.ToString("C") : "",
                salePriceHigh.MoneyValue.HasValue ? salePriceHigh.MoneyValue.Value.ToString("C") : "",
                confidence.MoneyValue.HasValue ? confidence.MoneyValue.Value.ToString("C") : "",
                GetConfidenceLevel(confidence.FloatValue.HasValue ? confidence.FloatValue.Value : 0.00)));
        }

        private IList<Statistic> GetGauges()
        {
            if (!_request.CarId.HasValue) return new List<Statistic>();

            return Statistics
                .Where(w => w.Car_ID == _request.CarId && w.Year_ID == _request.Year)
                .ToList();
        }

        private static readonly Func<double?, string> GetConfidenceLevel = (value) =>
        {
            if (value >= 0 && value <= 50)
                return "Low";

            if (value > 50 && value <= 75)
                return "Medium";

            return value > 75 ? "High" : "Low";
        };
    }
}
