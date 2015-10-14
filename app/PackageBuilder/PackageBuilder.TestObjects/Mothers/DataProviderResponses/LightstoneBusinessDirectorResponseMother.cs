using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses
{
    public class LightstoneBusinessDirectorResponseMother
    {
        public static IProvideDataFromLightstoneBusinessDirector Response
        {
            get
            {
                return new LightstoneBusinessDirectorResponseBuilder()
                    .With(DirectorMother.Director)
                    .Build();
            }
        }
    }
}