using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Packages;
using PackageBuilder.Domain.Entities.Enums.DataProviders;
namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberAudatexRequestPackage
    {
        public static IHavePackageForRequest LicenseNumberPackage()
        {

            return
                new LicensePlateNumberPackage(
                    new IAmDataProvider[] {new DataProvider(DataProviderName.Audatex, 16, 32.1M)}, Guid.NewGuid());
        }
    }
}
