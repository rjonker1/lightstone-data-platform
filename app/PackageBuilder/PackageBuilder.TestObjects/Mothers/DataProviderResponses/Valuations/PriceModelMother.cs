using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.Valuations
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