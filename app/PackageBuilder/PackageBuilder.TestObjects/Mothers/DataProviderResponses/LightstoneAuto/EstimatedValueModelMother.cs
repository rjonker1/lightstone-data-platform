using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneAuto;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto
{
    public class EstimatedValueModelMother
    {
        public static IRespondWithEstimatedValueModel EstimatedValue
        {
            get
            {
                return new EstimatedValueModelBuilder()
                    .With("R 88 100,00", "R 79 300,00", "R 96 900,00", "", "", "R 78 600,00", "R 70 800,00", "R 86 500,00", "", "")
                    .Build();
            }
        }
    }
}