using DataPlatform.Shared.Helpers.Builders;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses.Valuations
{
    public class VehicleValuationMother
    {
        public static IRespondWithValuation VehicleValuation
        {
            get
            {
                return new VehicleValuationBuilder()
                    .With(LinqList.Build(AmortisationFactorModelMother.AmortisationFactor))
                    .With(LinqList.Build(AreaFactorModelMother.AreaFactor))
                    .With(LinqList.Build(AuctionFactorModelMother.AuctionFactor))
                    .With(LinqList.Build(AccidentDistributionModelMother.AccidentDistribution))
                    .With(LinqList.Build(RepairIndexModelMother.RepairIndex))
                    .With(LinqList.Build(TotalSalesByAgeModelMother.TotalSalesByAge))
                    .With(LinqList.Build(TotalSalesByGenderModelMother.TotalSalesByGender))
                    .With(LinqList.Build(PriceModelMother.Price))
                    .With(LinqList.Build(FrequencyModelMother.Frequency))
                    .With(LinqList.Build(ConfidenceModelMother.Confidence))
                    .With(LinqList.Build(AmortisedValueModelMother.AmortisedValue))
                    .With(LinqList.Build(ImageGaugeModelMother.ImageGauge))
                    .With(LinqList.Build(EstimatedValueModelMother.EstimatedValue))
                    .With(LinqList.Build(SaleModelMother.Sale))
                    .Build();
            }
        }
    }
}