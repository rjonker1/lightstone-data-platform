using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses
{
    public class LightstoneBusinessCompanyResponseMother
    {
        public static IProvideDataFromLightstoneBusinessCompany Response
        {
            get
            {
                return new LightstoneBusinessCompanyResponseBuilder()
                    .With(CompanyMother.Company)
                    .Build();
            }
        }
    }
}