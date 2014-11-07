using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses
{
    public class IvidResponseMother
    {
        public static IProvideDataFromIvid Response
        {
            get
            {
                return new IvidResponseBuilder()
                    .With()
                    .Build();
            }
        }
    }
}