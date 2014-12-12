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
                    .With("", "", "")
                    .Build();
            }
        }
    }
}