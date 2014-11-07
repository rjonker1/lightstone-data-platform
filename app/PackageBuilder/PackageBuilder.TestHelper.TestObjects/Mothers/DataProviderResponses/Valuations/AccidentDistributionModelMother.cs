using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses.Valuations
{
    public class AccidentDistributionModelMother
    {
        public static IRespondWithAccidentDistributionModel AccidentDistribution
        {
            get
            {
                return new AccidentDistributionBuilder()
                    .With("")
                    .With(0d)
                    .Build();
            }
        }
    }
}