using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Services.Specifics;
using Lace.Domain.DataProviders.Lightstone.Queries;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Domain.DataProviders.Lightstone.Services
{
    public class BaseRetrievalMetric : IRetrieveValuationFromMetrics
    {
        //private IGetStatistics _getStatistics;
        //private IGetSales _getSales;
        private IGetValuationView _getValuation;

        private readonly IHaveCarInformation _request;
        private readonly IReadOnlyRepository _repository;

        public bool IsSatisfied { get; private set; }
        public IRespondWithValuation Valuation { get; private set; }

        public BaseRetrievalMetric(IHaveCarInformation request, IRespondWithValuation valuation,
            IReadOnlyRepository repository)
        {
            _request = request;
            _repository = repository;
            Valuation = valuation;
        }

        public IRetrieveValuationFromMetrics SetupDataSources()
        {
            _getValuation = new ValuationViewQuery(_repository);
            //_getStatistics = new StatisticsQuery(_repository);
            //_getSales = new SaleQuery(_repository);

            return this;
        }

        public IRetrieveValuationFromMetrics GenerateData()
        {
            _getValuation.GetValuation(_request);
            //_getStatistics.GetStatistics(_request);

            //if (!_getStatistics.Statistics.Any())
            //    throw new Exception(
            //        string.Format("Statistics data Lightstone Auto for Car id {0} could not be generated",
            //            _request.CarId));
            //_getSales.GetSales(_request);

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