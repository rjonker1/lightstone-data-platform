using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses
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