using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses.Valuations
{
    public class RepairIndexModelMother
    {
        public static IRespondWithRepairIndexModel RepairIndex
        {
            get
            {
                return new RepairIndexModelBuilder()
                    .With("")
                    .With(2014)
                    .With(0d)
                    .Build();
            }
        }
    }
}