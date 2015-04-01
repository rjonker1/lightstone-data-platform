using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Packages;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Test.Helper.Builders.Scans
{
    public class DriversLicenseSourcePackage
    {
        public static IAmPackageForRequest DriversLicenseDecryptionPackage()
        {
            return new DriversLicensePackage(new[] {DataProviderName.SignioDecryptDriversLicense}, Guid.NewGuid());
        }
    }
}
