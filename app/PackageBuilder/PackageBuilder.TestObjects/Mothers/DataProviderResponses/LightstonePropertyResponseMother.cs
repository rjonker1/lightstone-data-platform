using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneProperty;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses
{
    public class LightstonePropertyResponseMother
    {
        public static IProvideDataFromLightstoneProperty Response
        {
            get
            {
                return new LightstonePropertyResponseBuilder()
                    .With(PropertyMother.Property)
                    .Build();
            }
        }
    }
}