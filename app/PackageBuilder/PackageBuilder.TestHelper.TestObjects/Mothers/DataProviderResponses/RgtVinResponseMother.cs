using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses
{
    public class RgtVinResponseMother
    {
        public static IProvideDataFromRgtVin Response
        {
            get
            {
                return new RgtVinResponseBuilder()
                    .With(0, 0, 0, 0, 0)
                    .With("", "", "", "", "")
                    .Build();
            }
        }
    }
}