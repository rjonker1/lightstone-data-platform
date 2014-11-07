using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses.Valuations
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