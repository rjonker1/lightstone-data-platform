using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneAuto;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto
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