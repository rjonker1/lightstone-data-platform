using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses.Valuations
{
    public class AuctionFactorModelMother
    {
        public static IRespondWithAuctionFactorModel AuctionFactor
        {
            get
            {
                return new AuctionFactorModelBuilder()
                    .With("")
                    .With(0m)
                    .Build();
            }
        }
    }
}