using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Packages;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberRgtVinRequestPackage
    {
        public static IHavePackageForRequest LicenseNumberPackage()
        {
            return new LicensePlateNumberPackage(new IAmDataProvider[] {new DataProvider(DataProviderName.RgtVin, 5, 10)},
                Guid.NewGuid());
        }
    }
}
