using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.Valuations
{
    public class SaleModelMother
    {
        public static IRespondWithSaleModel Sale
        {
            get
            {
                return new SaleModelBuilder()
                    .With("Jul 30 2014 12:00AM", "108", "98900.00")
                    .Build();
            }
        }
    }
}