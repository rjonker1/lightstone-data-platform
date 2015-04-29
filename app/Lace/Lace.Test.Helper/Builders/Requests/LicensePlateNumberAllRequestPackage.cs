using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberAllRequestPackage
    {
        public static IHavePackageForRequest LicenseNumberPackage()
        {
            return new LicensePlateNumberPackage(new IAmDataProvider[]
            {
                new DataProvider(DataProviderName.Ivid, 5, 10),
                new DataProvider(DataProviderName.LightstoneAuto, 6, 12),
                new DataProvider(DataProviderName.IvidTitleHolder, 7, 14),
                new DataProvider(DataProviderName.RgtVin, 8, 16),
                new DataProvider(DataProviderName.Rgt, 9, 18),
                new DataProvider(DataProviderName.Audatex, 10, 20)
            }, Guid.NewGuid());
        }
    }
}
