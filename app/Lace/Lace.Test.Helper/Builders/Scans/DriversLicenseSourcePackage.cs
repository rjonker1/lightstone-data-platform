using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Scans
{
    public class DriversLicenseSourcePackage
    {
        public static IHavePackageForRequest DriversLicenseDecryptionPackage()
        {
            return
                new DriversLicensePackage(
                    new IAmDataProvider[] {new DataProvider(DataProviderName.SignioDecryptDriversLicense, 10, 20)},
                    Guid.NewGuid());
        }
    }
}
