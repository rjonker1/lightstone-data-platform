using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneAuto;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto
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