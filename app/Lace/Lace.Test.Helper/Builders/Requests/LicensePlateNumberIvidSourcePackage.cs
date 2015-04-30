using System;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberIvidSourcePackage
    {
        public static IHavePackageForRequest LicenseNumberPackage(string licensePlate, string packageName)
        {
            return new LicensePlateNumberPackage(
                new IAmDataProvider[]
                {
                    new DataProvider(DataProviderName.Ivid, 7, 14,
                        new  IvidStandardRequest(licensePlate, "Murray", packageName,
                            "murrayw@lightstone.co.za", "Murray", string.Empty))
                }, Guid.NewGuid());
        }
    }
}
