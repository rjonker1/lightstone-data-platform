using System;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses
{
    public class IvidTitleHolderResponseMother
    {
        public static IProvideDataFromIvidTitleHolder Response
        {
            get
            {
                return new IvidTitleHolderResponseBuilder()
                    .With("", false, "", DateTime.UtcNow, DateTime.UtcNow, "")
                    .Build();
            }
        }
    }
}