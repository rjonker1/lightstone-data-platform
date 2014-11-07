using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses.Valuations
{
    public class ConfidenceModelMother
    {
        public static IRespondWithConfidenceModel Confidence
        {
            get
            {
                return new ConfidenceModelBuilder()
                    .With("")
                    .With(2014)
                    .With(0d)
                    .Build();
            }
        }
    }
}