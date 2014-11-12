using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses.Valuations
{
    public class TotalSalesByGenderModelMother
    {
        public static IRespondWithTotalSalesByGenderModel TotalSalesByGender
        {
            get
            {
                return new TotalSalesByGenderModelBuilder() 
                    .With("", "")
                    .With(0d)
                    .Build();
            }
        }
    }
}