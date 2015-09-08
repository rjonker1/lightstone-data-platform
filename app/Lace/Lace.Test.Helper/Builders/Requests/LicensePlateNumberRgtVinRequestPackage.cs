using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberRgtVinRequestPackage
    {
        public static IHavePackageForRequest LicenseNumberPackage()
        {
            return
                new LicensePlateNumberPackage(
                    new IAmDataProvider[]
                    {new DataProvider(DataProviderName.VinMaster, 5, 10, RgtVinRequest.WithVin(null))},
                    Guid.NewGuid());
        }

        public static IHavePackageForRequest VinNumberPackage(string vinNumber)
        {
            return
                new LicensePlateNumberPackage(
                    new IAmDataProvider[] {new DataProvider(DataProviderName.VinMaster, 5, 10, RgtVinRequest.WithVin(vinNumber))},
                    Guid.NewGuid());
        }
    }
}
