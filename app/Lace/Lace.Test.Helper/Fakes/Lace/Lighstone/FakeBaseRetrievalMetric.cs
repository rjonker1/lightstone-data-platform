using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Domain.DataProviders.Lightstone.Services.Specifics;
using Lace.Domain.DataProviders.Lightstone.UnitOfWork;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeBaseRetrievalMetric : IRetrieveValuationFromMetrics
    {
        public bool IsSatisfied { get; private set; }
        public IRespondWithValuation Valuation { get; private set; }

        private IGetStatistics _getStatistics;
        private IGetMetrics _getMetrics;
        private IGetBands _getBands;
        private IGetMuncipalities _getMuncipalities;
        private IGetMakes _getMakes;
        private IGetSales _getSales;

        private readonly IHaveCarInformation _request;

        public FakeBaseRetrievalMetric(IHaveCarInformation request, IRespondWithValuation valuation)
        {
            _request = request;
            Valuation = valuation;
        }


        public IRetrieveValuationFromMetrics SetupDataSources()
        {
            _getStatistics = new StatisticsUnitOfWork(new FakeStatisticsRepository());
            _getMetrics = new MetricUnitOfWork(new FakeMetricRepository());
            _getBands = new BandUnitOfWork(new FakeBandsRepository());
            _getMuncipalities = new MuncipalityUnitOfWork(new FakeMunicipalityRepository());
            _getMakes = new MakeUnitOfWork(new FakeMakeRepository());
            _getSales = new SaleUnitOfWork(new FakeSaleRepository());

            return this;
        }

        public IRetrieveValuationFromMetrics BuildValuation()
        {
            if (_request.CarId == null || _request.Year == null) return this;


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

        public IRetrieveValuationFromMetrics GenerateData()
        {
            _getStatistics.GetStatistics(_request);
            _getMetrics.GetMetrics(_request);
            _getBands.GetBands(_request);
            _getMuncipalities.GetMunicipalities(_request);
            _getMakes.GetMakes(_request);
            _getSales.GetSales(_request);

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
                new TotalSalesByGenderMetric(_request, _getStatistics.Statistics, _getBands.Bands)
                    .Get()
                    .MetricResult;
        }

        private IEnumerable<IRespondWithTotalSalesByAgeModel> GetTotalSalesByAge()
        {
            return
                new TotalSalesByAgeMetric(_request, _getStatistics.Statistics, _getBands.Bands)
                    .Get()
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
