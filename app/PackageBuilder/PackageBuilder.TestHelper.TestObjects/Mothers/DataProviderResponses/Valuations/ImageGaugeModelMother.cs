using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.Valuations
{
    public class ImageGaugeModelMother
    {
        public static IRespondWithImageGaugeModel ImageGauge
        {
            get
            {
                return new ImageGaugeModelBuilder()
                    .With(0d, 0d, 0d, 0d)
                    .With("")
                    .Build();
            }
        }
    }
}