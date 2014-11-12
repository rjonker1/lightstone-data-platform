using System;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses
{
    public class IvidTitleHolderResponseMother
    {
        public static IProvideDataFromIvidTitleHolder Response
        {
            get
            {
                return new IvidTitleHolderResponseBuilder()
                    .With("", false, "", DateTime.Now, DateTime.Now, "")
                    .Build();
            }
        }
    }
}