using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Packages;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberIvidTitleHolderRequestPackage
    {
        public static IHavePackageForRequest LicenseNumberPackage()
        {
            return new LicensePlateNumberPackage(new[] { DataProviderName.IvidTitleHolder }, Guid.NewGuid());
        }
    }
}
