using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneAuto;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto
{
    public class FrequencyModelMother
    {
        public static IRespondWithFrequencyModel Frequency
        {
            get
            {
                return new FrequencyModelBuilder()
                    .With("")
                    .With(2014)
                    .With(0d)
                    .Build();
            }
        }
    }
}