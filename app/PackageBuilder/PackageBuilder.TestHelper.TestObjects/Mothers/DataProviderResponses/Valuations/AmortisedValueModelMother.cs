using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.Valuations
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