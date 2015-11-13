using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneAuto;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto
{
    public class SaleModelMother
    {
        public static IRespondWithSaleModel Sale1
        {
            get
            {
                return new SaleModelBuilder()
                    .With("Jul 30 2014 12:00AM", "108", "98900.00")
                    .Build();
            }
        }

        public static IRespondWithSaleModel Sale2
        {
            get
            {
                return new SaleModelBuilder()
                    .With("Jan 01 2014 12:00AM", "101", "1100.00")
                    .Build();
            }
        }
    }
}