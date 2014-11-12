using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses.Valuations
{
    public class PriceModelMother
    {
        public static IRespondWithPriceModel Price
        {
            get
            {
                return new PriceModelBuilder()
                    .With("")
                    .With(0m)
                    .Build();
            }
        }
    }
}