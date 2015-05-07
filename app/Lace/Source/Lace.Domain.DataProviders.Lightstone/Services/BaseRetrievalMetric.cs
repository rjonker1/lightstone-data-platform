using System;
using System.Collections.Generic;
using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Services.Specifics;
using Lace.Domain.DataProviders.Lightstone.UnitOfWork;
using Lace.Shared.DataProvider.Repositories;

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
            _getStatistics = new StatisticsUnitOfWork(_repository);
            _getMetrics = new MetricUnitOfWork(_repository);
            _getBands = new BandUnitOfWork(_repository);
            _getMuncipalities = new MuncipalityUnitOfWork(_repository);
            _getMakes = new MakeUnitOfWork(_repository);
            //_getCarType = new CarTypeUnitOfWork(_getStatistics.Statistics);
            _getSales = new SaleUnitOfWork(_repository);

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
            _getMakes.GetMakes(_request);
            //_getCarType.GetCarTypes(_request);
            _getSales.GetSales(_request);

            return this;
        }

        public IRetrieveValuationFromMetrics BuildValuation()
        {
            Valuation.AddImageGauages(GetImageGaugeMetrics());
            Valuation.AddAccidentDistribution(GetAccidentDistributionMetrics());
            Valuation.AddAmortisedValues(GetAmortisedValues());
            Valuation.AddAreaFactors(GetAreaFactors());
            Valuation.AddAuctionFactors(GetAuctionFactors());
            Valuation.AddRepairIndex((GetRepairIndex()));
            Valuation.AddTotalSalesByAge(GetTotalSalesByAge());
            Valuation.AddTotalSalesByGender(GetTotalSalesByGender());
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

        private IEnumerable<IRespondWithTotalSalesByGenderModel> GetTotalSalesByGender()
        {
            return
                new TotalSalesByGenderMetric(_request, _getStatistics.Statistics, _getBands.Bands).Get()
                    .MetricResult;
        }

        private IEnumerable<IRespondWithTotalSalesByAgeModel> GetTotalSalesByAge()
        {
            return
                new TotalSalesByAgeMetric(_request, _getStatistics.Statistics, _getBands.Bands).Get()
                    .MetricResult;
        }

        private IEnumerable<IRespondWithRepairIndexModel> GetRepairIndex()
        {
            return new RepairIndexMetric(_request, _getStatistics.Statistics, _getBands.Bands).Get().MetricResult;
        }

        private IEnumerable<IRespondWithAuctionFactorModel> GetAuctionFactors()
        {
            return new AuctionFactorsMetric(_request, _getStatistics.Statistics, _getMakes.Makes).Get().MetricResult;
        }

        private IEnumerable<IRespondWithAreaFactorModel> GetAreaFactors()
        {
            return new AreaFactorsMetric(_getStatistics.Statistics, _getMuncipalities.Municipalities).Get().MetricResult;
        }

        private IEnumerable<IRespondWithAmortisedValueModel> GetAmortisedValues()
        {
            return new AmortisedValueMetric(_request, _getStatistics.Statistics, _getBands.Bands).Get().MetricResult;
        }

        private IEnumerable<IRespondWithAccidentDistributionModel> GetAccidentDistributionMetrics()
        {
            return
                new AccidentDistributionMetric(_getStatistics.Statistics, _getBands.Bands).Get().MetricResult;
        }

        private IEnumerable<IRespondWithImageGaugeModel> GetImageGaugeMetrics()
        {
            return new ImageGaugesMetric(_getStatistics.Statistics, _getMetrics.Metrics).Get().MetricResult;
        }

        
    }
}
