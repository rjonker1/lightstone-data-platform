using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses
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