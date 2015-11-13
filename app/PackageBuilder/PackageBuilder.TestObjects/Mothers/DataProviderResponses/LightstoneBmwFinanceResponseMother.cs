using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses
{
    public class LightstoneBmwFinanceResponseMother
    {
        public static IProvideDataFromBmwFinance Response
        {
            get
            {
                return new LightstoneBmwFinanceResponseBuilder()
                    .With(FinanceMother.Finance)
                    .Build();
            }
        }
    }
}