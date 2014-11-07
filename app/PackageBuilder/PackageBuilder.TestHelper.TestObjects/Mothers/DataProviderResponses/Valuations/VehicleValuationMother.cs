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
                    .With(new []{ AmortisationFactorModelMother.AmortisationFactor })
                    .With(new []{ AreaFactorModelMother.AreaFactor })
                    .With(new []{ AuctionFactorModelMother.AuctionFactor })
                    .With(new []{ AccidentDistributionModelMother.AccidentDistribution })
                    .With(new []{ RepairIndexModelMother.RepairIndex })
                    .With(new []{ TotalSalesByAgeModelMother.TotalSalesByAge })
                    .With(new []{ TotalSalesByGenderModelMother.TotalSalesByGender })
                    .With(new []{ PriceModelMother.Price })
                    .With(new []{ FrequencyModelMother.Frequency })
                    .With(new []{ ConfidenceModelMother.Confidence })
                    .With(new []{ AmortisedValueModelMother.AmortisedValue })
                    .With(new []{ ImageGaugeModelMother.ImageGauge })
                    .With(new []{ EstimatedValueModelMother.EstimatedValue })
                    .With(new []{ SaleModelMother.Sale })
                    .Build();
            }
        }
    }
}