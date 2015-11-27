using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Services.Specifics;
using Lace.Toolbox.Database.Base;

namespace Lace.Domain.DataProviders.Lightstone.Services
{
    public class BaseRetrievalMetric : IRetrieveValuationFromMetrics
    {
        private readonly IGetValuationView _getValuation;
        private readonly IHaveCarInformation _request;

        public bool IsSatisfied { get; private set; }
        public IRespondWithValuation Valuation { get; private set; }

        public BaseRetrievalMetric(IHaveCarInformation request, IRespondWithValuation valuation,
            IGetValuationView getValuation)
        {
            _request = request;
            _getValuation = getValuation;
            Valuation = valuation;
        }

        public IRetrieveValuationFromMetrics GenerateData()
        {
            _getValuation.GetValuation(_request);
            return this;
        }

        public IRetrieveValuationFromMetrics BuildValuation()
        {
            Valuation.AddImageGauages(GetImageGaugeMetrics());
            Valuation.AddAmortisedValues(GetAmortisedValues());
            Valuation.AddEstimatedValue(GetEstimatedValues());
            Valuation.AddLastFiveSales(GetLastFiveSales());
            IsSatisfied = true;
            return this;
        }

        private IEnumerable<IRespondWithSaleModel> GetLastFiveSales()
        {
            return new LastFiveSalesMetric(_getValuation.Sales).Get().MetricResult;
        }

        private IEnumerable<IRespondWithEstimatedValueModel> GetEstimatedValues()
        {
            return new EstimatedValuesMetric(_request, _getValuation.Statistics).Get().MetricResult;
        }
        private IEnumerable<IRespondWithAmortisedValueModel> GetAmortisedValues()
        {
            return new AmortisedValueMetric(_request, _getValuation.Statistics).Get().MetricResult;
        }
        private IEnumerable<IRespondWithImageGaugeModel> GetImageGaugeMetrics()
        {
            return new ImageGaugesMetric(_getValuation.Statistics).Get().MetricResult;
        }
    }
}