using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Packages;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberRgtRequestPackage
    {
        public static IAmPackageForRequest LicenseNumberPackage()
        {
            return new LicensePlateNumberPackage(new[] { DataProviderName.Rgt }, Guid.NewGuid());
        }
    }
}
