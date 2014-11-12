using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses
{
    public class RgtResponseMother
    {
        public static IProvideDataFromRgt Response
        {
            get
            {
                return new RgtResponseBuilder()
                    .With("", 204, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
                    .Build();
            }
        }
    }
}