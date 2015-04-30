using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberLightstoneAutoPackage
    {
        public static IHavePackageForRequest LicenseNumberPackage(int carid, int year)
        {
            return
                new LicensePlateNumberPackage(
                    new IAmDataProvider[]
                    {
                        new DataProvider(DataProviderName.LightstoneAuto, 90, 92,
                            LightstoneAutoRequest.WithCarIdAndYear(carid, year))
                    }, Guid.NewGuid());
        }
    }

    public class VinNumberLightstoneAutoPackage
    {
        public static IHavePackageForRequest VinNumberPackage(string vinNumber)
        {
            return
                new LicensePlateNumberPackage(
                    new IAmDataProvider[]
                    {
                        new DataProvider(DataProviderName.LightstoneAuto, 90, 92,
                            LightstoneAutoRequest.WithVin(vinNumber))
                    }, Guid.NewGuid());
        }
    }
}
