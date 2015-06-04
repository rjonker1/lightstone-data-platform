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

            return
                new DriversLicensePackage(
                    new IAmDataProvider[]
                    {
                        new DataProvider(DataProviderName.SignioDecryptDriversLicense, 10, 20,
                            SignioDriversLicenseRequest.Request(DriversLicenseScan.GetBase64String(), string.Empty,
                                new Guid("5A3DA2CD-6036-440C-B591-58C70B6F2EF2"), "jonathan@dnacars.co.za"))
                    },
                    Guid.NewGuid());
        }
    }
}
