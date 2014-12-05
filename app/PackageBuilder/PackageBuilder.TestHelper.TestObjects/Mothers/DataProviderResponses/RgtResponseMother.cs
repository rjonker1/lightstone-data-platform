using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses
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