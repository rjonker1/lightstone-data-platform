using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Scans
{
    public class DriversLicenseSourcePackage
    {
        public static IHavePackageForRequest DriversLicenseDecryptionPackage()
        {
            //TODO: need to get signio request from package builder contracts..
            return
                new DriversLicensePackage(
                    new IAmDataProvider[] {new DataProvider(DataProviderName.SignioDecryptDriversLicense, 10, 20, null)},
                    Guid.NewGuid());
        }
    }
}
