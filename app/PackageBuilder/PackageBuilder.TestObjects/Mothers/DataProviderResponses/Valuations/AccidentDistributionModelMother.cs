using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.Valuations
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