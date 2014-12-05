using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.Valuations
{
    public class EstimatedValueModelMother
    {
        public static IRespondWithEstimatedValueModel EstimatedValue
        {
            get
            {
                return new EstimatedValueModelBuilder()
                    .With("", "", "", "", "")
                    .Build();
            }
        }
    }
}