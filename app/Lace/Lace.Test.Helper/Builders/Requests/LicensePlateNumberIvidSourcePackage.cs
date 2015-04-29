using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberIvidSourcePackage
    {
        public static IHavePackageForRequest LicenseNumberPackage()
        {
            return new LicensePlateNumberPackage(
                new IAmDataProvider[] {new DataProvider(DataProviderName.Ivid, 7, 14)}, Guid.NewGuid());
        }
    }
}
