using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.Ivid;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.Ivid
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