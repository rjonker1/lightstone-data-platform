using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.Valuations
{
    public class VehicleValuationMother
    {
        public static IRespondWithValuation VehicleValuation
        {
            get
            {
                return new VehicleValuationBuilder()
                    //.With(AmortisationFactorModelMother.AmortisationFactor))
                    //.With(AreaFactorModelMother.AreaFactor))
                    //.With(AuctionFactorModelMother.AuctionFactor))
                    //.With(AccidentDistributionModelMother.AccidentDistribution))
                    //.With(RepairIndexModelMother.RepairIndex))
                    //.With(TotalSalesByAgeModelMother.TotalSalesByAge))
                    //.With(TotalSalesByGenderModelMother.TotalSalesByGender))
                    .With(PriceModelMother.Price)
                    .With(FrequencyModelMother.Frequency)
                    .With(ConfidenceModelMother.Confidence)
                    .With(AmortisedValueModelMother.AmortisedValue)
                    .With(ImageGaugeModelMother.ImageGauge)
                    .With(EstimatedValueModelMother.EstimatedValue)
                    .With(SaleModelMother.Sale)
                    .Build();
            }
        }
    }
}