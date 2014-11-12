using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto.Metric;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses.Valuations
{
    public class TotalSalesByAgeModelMother
    {
        public static IRespondWithTotalSalesByAgeModel TotalSalesByAge
        {
            get
            {
                return new TotalSalesByAgeModelBuilder()
                    .With("")
                    .With(new []{new Pair<string, double>("", 0d), })
                    .Build();
            }
        }
    }
}