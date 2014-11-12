using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses.Valuations
{
    public class AmortisationFactorModelMother
    {
        public static IRespondWithAmortisationFactorModel AmortisationFactor
        {
            get
            {
                return new AmortisationFactorBuilder()
                    .With(2014)
                    .With(0d)
                    .Build();
            }
        }
    }
}