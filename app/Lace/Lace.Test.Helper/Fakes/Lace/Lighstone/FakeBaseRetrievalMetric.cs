using System.Collections.Generic;
using Lace.Models.Responses.Sources.Specifics;
using Lace.Request;
using Lace.Source.Lightstone.DataObjects;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Metrics.Specifics;

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
        private IGetCarType _getCarType;
        private IGetSales _getSales;

        private readonly IProvideCarInformationForRequest _request;

        public FakeBaseRetrievalMetric(IProvideCarInformationForRequest request, IRespondWithValuation valuation)
        {
            _request = request;
            Valuation = valuation;
        }


        public IRetrieveValuationFromMetrics SetupDataSources()
        {
            _getStatistics = new StatisticsData(new FakeStatisticsRepository());
            _getMetrics = new MetricData(new FakeMetricRepository());
            _getBands = new BandData(new FakeBandsRepository());
            _getMuncipalities = new MuncipalityData(new FakeMunicipalityRepository());
            _getMakes = new MakeData(new FakeMakeRepository());
            _getCarType = new CarTypeData(new FakeCarTypeRepository());
            _getSales = new SaleData(new FakeSaleRepository());

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
            _getCarType.GetCarTypes(_request);
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
                new TotalSalesByGenderMetric(_request, _getStatistics.Statistics, _getBands.Bands, _getCarType.CarTypes)
                    .Get()
                    .MetricResult;
        }

        private IEnumerable<IRespondWithTotalSalesByAgeModel> GetTotalSalesByAge()
        {
            return
                new TotalSalesByAgeMetric(_request, _getStatistics.Statistics, _getBands.Bands, _getCarType.CarTypes)
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
