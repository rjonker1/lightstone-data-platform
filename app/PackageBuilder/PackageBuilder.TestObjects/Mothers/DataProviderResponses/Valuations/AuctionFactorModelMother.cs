using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.Valuations
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