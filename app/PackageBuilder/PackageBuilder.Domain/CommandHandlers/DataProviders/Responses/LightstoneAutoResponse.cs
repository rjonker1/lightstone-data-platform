using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class LightstoneAutoResponse
    {
        public Lace.Domain.Core.Entities.LightstoneAutoResponse DefaultLightstoneResponse()
        {
            var vehicleValuation = new Valuation();
            vehicleValuation.AddAmortisationFactors(new[] { new AmortisationFactorModel(0, 0d) });
            vehicleValuation.AddAreaFactors(new[] { new AreaFactorModel("", 0d) });
            vehicleValuation.AddAuctionFactors(new[] { new AuctionFactorModel("", 0m) });
            vehicleValuation.AddAccidentDistribution(new[] { new AccidentDistributionModel("", 0d) });
            vehicleValuation.AddRepairIndex(new[] { new RepairIndexModel(0, "", 0d) });
            vehicleValuation.AddTotalSalesByAge(new[] { new TotalSalesByAgeModel() });
            vehicleValuation.AddTotalSalesByGender(new[] { new TotalSalesByGenderModel("", "", 0d) });
            vehicleValuation.AddPrices(new[] { new PriceModel("", 0m) });
            vehicleValuation.AddFrequency(new[] { new FrequencyModel("", 0, 0d) });
            vehicleValuation.AddConfidence(new[] { new ConfidenceModel("", 0, 0d) });
            vehicleValuation.AddAmortisedValues(new[] { new AmortisedValueModel("", 0m) });
            vehicleValuation.AddImageGauages(new[] { new ImageGaugeModel(null, null, null, null, "") });
            vehicleValuation.AddEstimatedValue(new[] { new EstimatedValueModel() });
            vehicleValuation.AddLastFiveSales(new[] { new SaleModel("", "", "") });
            return new Lace.Domain.Core.Entities.LightstoneAutoResponse(0, 0, "", "", "", "", "", vehicleValuation);
        } 
    }
}