using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.Valuations
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