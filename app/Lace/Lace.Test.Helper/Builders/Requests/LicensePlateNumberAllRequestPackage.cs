using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Packages;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberAllRequestPackage
    {
        public static IAmPackageForRequest LicenseNumberPackage()
        {
            return new LicensePlateNumberPackage(new[]
            {
                DataProviderName.Ivid,
                DataProviderName.LightstoneAuto,
                DataProviderName.IvidTitleHolder,
                DataProviderName.RgtVin,
                DataProviderName.Rgt,
                DataProviderName.Audatex
            }, Guid.NewGuid());
        }
    }
}
