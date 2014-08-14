using System.Collections.Generic;

namespace Lace.Models.Lightstone
{
    public interface IRespondWithValuation
    {
        IEnumerable<IRespondWithAmortisationFactorModel> AmortisationFactors { get; }
        IEnumerable<IRespondWithAreaFactorModel> AreaFactors { get; }
        IEnumerable<IRespondWithAuctionFactorModel> AuctionFactors { get; }
        IEnumerable<IRespondWithAccidentDistributionModel> AccidentDistribution { get; }
        IEnumerable<IRespondWithRepairIndexModel> RepairIndex { get; }
        IEnumerable<IRespondWithTotalSalesByAgeModel> TotalSalesByAge { get; }
        IEnumerable<IRespondWithTotalSalesByGenderModel> TotalSalesByGender { get; }
        IEnumerable<IRespondWithEstimatedValueModel> EstimatedValue { get; }
        IEnumerable<IRespondWithSaleModel> LastFiveSales { get; }
        IEnumerable<IRespondWithPriceModel> Prices { get; }
        IEnumerable<IRespondWithFrequencyModel> Frequency { get; }
        IEnumerable<IRespondWithConfidenceModel> Confidence { get; }
        IEnumerable<IRespondWithAmortisedValueModel> AmortisedValues { get; }
        IEnumerable<IRespondWithImageGaugeModel> ImageGauges { get; }
    }
}