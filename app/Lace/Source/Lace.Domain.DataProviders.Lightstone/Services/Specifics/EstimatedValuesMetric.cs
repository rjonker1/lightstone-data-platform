using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Entities;
using Lace.Shared.DataProvider.Models;

namespace Lace.Domain.DataProviders.Lightstone.Services.Specifics
{
    public class EstimatedValuesMetric : IRetrieveATypeOfMetric<EstimatedValueModel>
    {
        public List<EstimatedValueModel> MetricResult { get; private set; }
        public IEnumerable<Statistic> Statistics { get; private set; }

        private IList<Statistic> _gauges;
        private readonly IHaveCarInformation _request;

        public EstimatedValuesMetric(IHaveCarInformation request, IEnumerable<Statistic> statistics)
        {
            Statistics = statistics;
            _request = request;
            MetricResult = new List<EstimatedValueModel>();
        }

        public IRetrieveATypeOfMetric<EstimatedValueModel> Get()
        {
            _gauges = GetGauges();

            if (!_gauges.Any()) return this;

            var estimatedValues = new EstimatedValueModel();

            SetRetailEstimatedValues(estimatedValues);
            SetTradeEstimatedValues(estimatedValues);

            MetricResult.Add(estimatedValues);

            return this;
        }

        private void SetRetailEstimatedValues(IRespondWithEstimatedValueModel model)
        {
            var estimatedPrice = _gauges.FirstOrDefault(w => w.MetricId == (int) MetricTypes.RetailEstimatedPrice);
            var salePriceHigh = _gauges.FirstOrDefault(w => w.MetricId == (int)MetricTypes.RetailPriceHigh);
            var salePriceLow = _gauges.FirstOrDefault(w => w.MetricId == (int)MetricTypes.RetailPriceLow);
            var confidence = _gauges.FirstOrDefault(w => w.MetricId == (int)MetricTypes.RetailConfidence);


            if (estimatedPrice == null || salePriceHigh == null || salePriceLow == null || confidence == null) return;

            model.SetRetailEstimatedValues(
                estimatedPrice.MoneyValue.HasValue ? estimatedPrice.MoneyValue.Value.ToString("C") : "",
                salePriceLow.MoneyValue.HasValue ? salePriceLow.MoneyValue.Value.ToString("C") : "",
                salePriceHigh.MoneyValue.HasValue ? salePriceHigh.MoneyValue.Value.ToString("C") : "",
                confidence.FloatValue.HasValue ? confidence.FloatValue.Value.ToString(CultureInfo.CurrentCulture) : "",
                GetConfidenceLevel(confidence.FloatValue.HasValue ? confidence.FloatValue.Value : 0.00));
        }

        private void SetTradeEstimatedValues(IRespondWithEstimatedValueModel model)
        {
            var estimatedPrice = _gauges.FirstOrDefault(w => w.MetricId == (int)MetricTypes.TradeEstimatedPrice);
            var salePriceHigh = _gauges.FirstOrDefault(w => w.MetricId == (int)MetricTypes.TradePriceHigh);
            var salePriceLow = _gauges.FirstOrDefault(w => w.MetricId == (int)MetricTypes.TradePriceLow);
            var confidence = _gauges.FirstOrDefault(w => w.MetricId == (int)MetricTypes.TradeConfidence);


            if (estimatedPrice == null || salePriceHigh == null || salePriceLow == null || confidence == null) return;

            model.SetTradeEstimatedValues(
                estimatedPrice.MoneyValue.HasValue ? estimatedPrice.MoneyValue.Value.ToString("C") : "",
                salePriceLow.MoneyValue.HasValue ? salePriceLow.MoneyValue.Value.ToString("C") : "",
                salePriceHigh.MoneyValue.HasValue ? salePriceHigh.MoneyValue.Value.ToString("C") : "",
                confidence.FloatValue.HasValue ? confidence.FloatValue.Value.ToString(CultureInfo.CurrentCulture) : "",
                GetConfidenceLevel(confidence.FloatValue.HasValue ? confidence.FloatValue.Value : 0.00));
        }

        private IList<Statistic> GetGauges()
        {
            if (!_request.HasValidCarIdAndYear()) return new List<Statistic>();

            return Statistics
                .Where(w => w.CarId == _request.CarId && w.YearId == _request.Year)
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
