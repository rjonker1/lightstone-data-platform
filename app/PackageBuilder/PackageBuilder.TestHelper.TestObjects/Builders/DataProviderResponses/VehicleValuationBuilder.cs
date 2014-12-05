using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses
{
    public class VehicleValuationBuilder
    {
        private readonly Valuation _valuation = new Valuation();
        private IEnumerable<IRespondWithAmortisationFactorModel> _amortisationFactorModels;

        public IRespondWithValuation Build()
        {
            return _valuation;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithAmortisationFactorModel> amortisationFactorModels)
        {
            _valuation.AddAmortisationFactors(amortisationFactorModels);
            return this;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithAreaFactorModel> areaFactorModels)
        {
            _valuation.AddAreaFactors(areaFactorModels);
            return this;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithAuctionFactorModel> auctionFactorModels)
        {
            _valuation.AddAuctionFactors(auctionFactorModels);
            return this;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithAccidentDistributionModel> accidentDistributionModels)
        {
            _valuation.AddAccidentDistribution(accidentDistributionModels);
            return this;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithRepairIndexModel> repairIndexModels)
        {
            _valuation.AddRepairIndex(repairIndexModels);
            return this;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithTotalSalesByAgeModel> totalSalesByAgeModels)
        {
            _valuation.AddTotalSalesByAge(totalSalesByAgeModels);
            return this;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithTotalSalesByGenderModel> totalSalesByGenderModels)
        {
            _valuation.AddTotalSalesByGender(totalSalesByGenderModels);
            return this;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithPriceModel> priceModels)
        {
            _valuation.AddPrices(priceModels);
            return this;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithFrequencyModel> frequencyModels)
        {
            _valuation.AddFrequency(frequencyModels);
            return this;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithConfidenceModel> confidenceModels)
        {
            _valuation.AddConfidence(confidenceModels);
            return this;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithAmortisedValueModel> amortisedValueModels)
        {
            _valuation.AddAmortisedValues(amortisedValueModels);
            return this;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithImageGaugeModel> imageGaugeModels)
        {
            _valuation.AddImageGauages(imageGaugeModels);
            return this;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithEstimatedValueModel> estimatedValueModels)
        {
            _valuation.AddEstimatedValue(estimatedValueModels);
            return this;
        }

        public VehicleValuationBuilder With(IEnumerable<IRespondWithSaleModel> saleModels)
        {
            _valuation.AddLastFiveSales(saleModels);
            return this;
        }
    }
}