using System;
using System.Collections.Generic;
using System.Linq;
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
        private IGetStatistics _getStatistics;
        private IGetMetrics _getMetrics;
        private IGetBands _getBands;
        private IGetMuncipalities _getMuncipalities;
        private IGetMakes _getMakes;
        private IGetSales _getSales;

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
            _getStatistics = new StatisticsQuery(_repository);
            _getMetrics = new MetricQuery(_repository);
            _getBands = new BandQuery(_repository);
            _getMuncipalities = new MuncipalityQuery(_repository);
            _getMakes = new MakeQuery(_repository);
            //_getCarType = new CarTypeUnitOfWork(_getStatistics.Statistics);
            _getSales = new SaleQuery(_repository);

            return this;
        }

        public IRetrieveValuationFromMetrics GenerateData()
        {
            _getStatistics.GetStatistics(_request);

            if (!_getStatistics.Statistics.Any())
                throw new Exception(
                    string.Format("Statistics data Lightstone Auto for Car id {0} could not be generated",
                        _request.CarId));

            _getMetrics.GetMetrics(_request);
            _getBands.GetBands(_request);
            _getMuncipalities.GetMunicipalities(_request);
            _getMakes.GetMakes(_request); //TODO: This might not be relevant any more. Need to see if it can be removed!
            _getSales.GetSales(_request);

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
            return new LastFiveSalesMetric(_getSales.Sales, _getMuncipalities.Municipalities).Get().MetricResult;
        }

        private IEnumerable<IRespondWithEstimatedValueModel> GetEstimatedValues()
        {
            return new EstimatedValuesMetric(_request, _getStatistics.Statistics).Get().MetricResult;
        }
        private IEnumerable<IRespondWithAmortisedValueModel> GetAmortisedValues()
        {
            return new AmortisedValueMetric(_request, _getStatistics.Statistics, _getBands.Bands).Get().MetricResult;
        }

        private IEnumerable<IRespondWithImageGaugeModel> GetImageGaugeMetrics()
        {
            return new ImageGaugesMetric(_getStatistics.Statistics, _getMetrics.Metrics).Get().MetricResult;
        }
    }
}