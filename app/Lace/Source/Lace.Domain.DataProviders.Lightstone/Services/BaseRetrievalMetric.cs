﻿using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Factory;
using Lace.Domain.DataProviders.Lightstone.Services.Specifics;
using Lace.Domain.DataProviders.Lightstone.UnitOfWork;

namespace Lace.Domain.DataProviders.Lightstone.Services
{
    public class BaseRetrievalMetric : IRetrieveValuationFromMetrics
    {
        private IGetStatistics _getStatistics;
        private IGetMetrics _getMetrics;
        private IGetBands _getBands;
        private IGetMuncipalities _getMuncipalities;
        private IGetMakes _getMakes;
        private IGetCarType _getCarType;
        private IGetSales _getSales;

        private readonly IProvideCarInformationForRequest _request;
        private readonly ISetupRepository _repositories;

        public bool IsSatisfied { get; private set; }
        public IRespondWithValuation Valuation { get; private set; }

        public BaseRetrievalMetric(IProvideCarInformationForRequest request, IRespondWithValuation valuation,
            ISetupRepository repositories)
        {
            _request = request;
            _repositories = repositories;
            Valuation = valuation;
        }

        public IRetrieveValuationFromMetrics SetupDataSources()
        {
            _getStatistics = new StatisticsUnitOfWork(_repositories.StatisticRepository());
            _getMetrics = new MetricUnitOfWork(_repositories.MetricRepository());
            _getBands = new BandUnitOfWork(_repositories.BandRepository());
            _getMuncipalities = new MuncipalityUnitOfWork(_repositories.MuncipalityRepository());
            _getMakes = new MakeUnitOfWork(_repositories.MakeRepository());
            _getCarType = new CarTypeUnitOfWork(_repositories.CarTypeRepository());
            _getSales = new SaleUnitOfWork(_repositories.SaleRepository());

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
                new TotalSalesByGenderMetric(_request, _getStatistics.Statistics, _getBands.Bands, _getCarType.CarTypes).Get()
                    .MetricResult;
        }

        private IEnumerable<IRespondWithTotalSalesByAgeModel> GetTotalSalesByAge()
        {
            return
                new TotalSalesByAgeMetric(_request, _getStatistics.Statistics, _getBands.Bands, _getCarType.CarTypes).Get()
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