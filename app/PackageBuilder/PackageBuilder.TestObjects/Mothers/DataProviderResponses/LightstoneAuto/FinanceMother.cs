using System;
using Lace.Domain.Core.Contracts.DataProviders.Finance;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto
{
    public class FinanceMother
    {
        public static IRespondWithBmwFinance Finance
        {
            get
            {
                return new FinanceBuilder()
                    .With(2008, 12354785.025m)
                    .With(new DateTime(2015, 01, 01), new DateTime(2015, 10, 15))
                    .With(
                    "Chassis",
                    "DealStatus",
                    "Description",
                    "Engine",
                    "FinanceHouse",
                    "ProductCategory",
                    "RegistrationNumber"
                    )
                    .Build();
            }
        }
    }
}