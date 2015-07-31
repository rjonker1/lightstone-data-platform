using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses
{
    public class VehicleValuationBuilder
    {
        private readonly Valuation _valuation = new Valuation();
        //private params IRespondWithAmortisationFactorModel> _amortisationFactorModels;

        public IRespondWithValuation Build()
        {
            return _valuation;
        }

        //public VehicleValuationBuilder With(params IRespondWithAmortisationFactorModel> amortisationFactorModels)
        //{
        //    _valuation.AddAmortisationFactors(amortisationFactorModels);
        //    return this;
        //}

        //public VehicleValuationBuilder With(params IRespondWithAreaFactorModel> areaFactorModels)
        //{
        //    _valuation.AddAreaFactors(areaFactorModels);
        //    return this;
        //}

        //public VehicleValuationBuilder With(params IRespondWithAuctionFactorModel> auctionFactorModels)
        //{
        //    _valuation.AddAuctionFactors(auctionFactorModels);
        //    return this;
        //}

        //public VehicleValuationBuilder With(params IRespondWithAccidentDistributionModel> accidentDistributionModels)
        //{
        //    _valuation.AddAccidentDistribution(accidentDistributionModels);
        //    return this;
        //}

        //public VehicleValuationBuilder With(params IRespondWithRepairIndexModel> repairIndexModels)
        //{
        //    _valuation.AddRepairIndex(repairIndexModels);
        //    return this;
        //}

        //public VehicleValuationBuilder With(params IRespondWithTotalSalesByAgeModel> totalSalesByAgeModels)
        //{
        //    _valuation.AddTotalSalesByAge(totalSalesByAgeModels);
        //    return this;
        //}

        //public VehicleValuationBuilder With(params IRespondWithTotalSalesByGenderModel> totalSalesByGenderModels)
        //{
        //    _valuation.AddTotalSalesByGender(totalSalesByGenderModels);
        //    return this;
        //}

        public VehicleValuationBuilder With(params IRespondWithPriceModel[] priceModels)
        {
            _valuation.AddPrices(priceModels);
            return this;
        }

        public VehicleValuationBuilder With(params IRespondWithFrequencyModel[] frequencyModels)
        {
            _valuation.AddFrequency(frequencyModels);
            return this;
        }

        public VehicleValuationBuilder With(params IRespondWithConfidenceModel[] confidenceModels)
        {
            _valuation.AddConfidence(confidenceModels);
            return this;
        }

        public VehicleValuationBuilder With(params IRespondWithAmortisedValueModel[] amortisedValueModels)
        {
            _valuation.AddAmortisedValues(amortisedValueModels);
            return this;
        }

        public VehicleValuationBuilder With(params IRespondWithImageGaugeModel[] imageGaugeModels)
        {
            _valuation.AddImageGauages(imageGaugeModels);
            return this;
        }

        public VehicleValuationBuilder With(params IRespondWithEstimatedValueModel[] estimatedValueModels)
        {
            _valuation.AddEstimatedValue(estimatedValueModels);
            return this;
        }

        public VehicleValuationBuilder With(params IRespondWithSaleModel[] saleModels)
        {
            _valuation.AddLastFiveSales(saleModels);
            return this;
        }
    }
}