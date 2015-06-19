using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberAllRequestPackage
    {

        public static IHavePackageForRequest LicenseNumberOnlyPackage(string licensePlate, string packageName)
        {
            return new LicensePlateNumberPackage(new IAmDataProvider[]
            {
                new DataProvider(DataProviderName.Ivid, 5, 10,
                    new IvidStandardRequest(licensePlate, "Murray", packageName,
                        "murrayw@lightstone.co.za", "Murray", string.Empty)),
                new DataProvider(DataProviderName.LightstoneAuto, 6, 12, LightstoneAutoRequest.WithVin(null)),
                new DataProvider(DataProviderName.IvidTitleHolder, 7, 14,
                    IvidTitleHolderRequest.WithVin(null, "murrayw@lightstone.co.za", "Murray")),
                new DataProvider(DataProviderName.RgtVin, 8, 16, RgtVinRequest.WithVin(null)),
                new DataProvider(DataProviderName.Rgt, 9, 18, RgtRequestType.WithCarId(null)) //,
                // new DataProvider(DataProviderName.Audatex, 10, 20)
            }, Guid.NewGuid());
        }
        public static IHavePackageForRequest LicenseNumberPackage(string licensePlate, string packageName)
        {
            return new LicensePlateNumberPackage(new IAmDataProvider[]
            {
                new DataProvider(DataProviderName.Ivid, 5, 10,
                    new IvidStandardRequest(licensePlate, "Murray", packageName,
                        "murrayw@lightstone.co.za", "Murray", string.Empty)),
                new DataProvider(DataProviderName.LightstoneAuto, 6, 12, LightstoneAutoRequest.WithVin("SB1KV58E40F039277")),
                new DataProvider(DataProviderName.IvidTitleHolder, 7, 14,
                    IvidTitleHolderRequest.WithVin(null, "murrayw@lightstone.co.za", "Murray")),
                new DataProvider(DataProviderName.RgtVin, 8, 16, RgtVinRequest.WithVin("SB1KV58E40F039277")),
                new DataProvider(DataProviderName.Rgt, 9, 18, RgtRequestType.WithCarId("107483")) //,
                // new DataProvider(DataProviderName.Audatex, 10, 20)
            }, Guid.NewGuid());
        }
    }
}
