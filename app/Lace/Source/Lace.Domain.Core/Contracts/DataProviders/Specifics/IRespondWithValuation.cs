using System.Collections.Generic;
using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithValuation : IAddValuationItem, IProvideType
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