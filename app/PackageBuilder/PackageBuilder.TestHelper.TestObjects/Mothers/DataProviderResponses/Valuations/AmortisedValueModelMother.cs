using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses.Valuations
{
    public class AmortisedValueModelMother
    {
        public static IRespondWithAmortisedValueModel AmortisedValue
        {
            get
            {
                return new AmortisedValueModelBuilder()
                    .With("")
                    .With(0m)
                    .Build();
            }
        }
    }
}