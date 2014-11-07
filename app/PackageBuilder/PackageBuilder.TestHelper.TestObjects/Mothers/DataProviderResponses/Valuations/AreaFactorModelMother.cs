using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses.Valuations
{
    public class AreaFactorModelMother
    {
        public static IRespondWithAreaFactorModel AreaFactor
        {
            get
            {
                return new AreaFactorBuilder()
                    .With("")
                    .With(0d)
                    .Build();
            }
        }
    }
}