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
                new DataProvider(DataProviderName.LightstoneAuto, 6, 12, LightstoneAutoRequest.Empty()),
                new DataProvider(DataProviderName.IvidTitleHolder, 7, 14,
                    IvidTitleHolderRequest.WithVin(null, "murrayw@lightstone.co.za", "Murray")),
                new DataProvider(DataProviderName.VinMaster, 8, 16, RgtVinRequest.Empty()),
                new DataProvider(DataProviderName.LsaSpecifications, 9, 18, RgtRequestType.Empty())
            }, Guid.NewGuid());
        }
        public static IHavePackageForRequest LicenseNumberPackage(string licensePlate, string packageName)
        {
            return new LicensePlateNumberPackage(new IAmDataProvider[]
            {
                new DataProvider(DataProviderName.Ivid, 5, 10,
                    new IvidStandardRequest(licensePlate, "Murray", packageName,
                        "murrayw@lightstone.co.za", "Murray", string.Empty)),
                new DataProvider(DataProviderName.LightstoneAuto, 6, 12, LightstoneAutoRequest.Empty()),
                new DataProvider(DataProviderName.IvidTitleHolder, 7, 14,
                    IvidTitleHolderRequest.WithVin(null, "murrayw@lightstone.co.za", "Murray")),
                new DataProvider(DataProviderName.VinMaster, 8, 16, RgtVinRequest.Empty()),
                new DataProvider(DataProviderName.LsaSpecifications, 9, 18, RgtRequestType.Empty()) 
            }, Guid.NewGuid());
        }
    }

    public class VinNumberRequestPackage
    {
        public static IHavePackageForRequest LsAutoRgtAndRgitVinPackage(string vinNumber)
        {
            return new LicensePlateNumberPackage(new IAmDataProvider[]
            {
                new DataProvider(DataProviderName.LightstoneAuto, 6, 12, LightstoneAutoRequest.WithVin(vinNumber)),
                new DataProvider(DataProviderName.VinMaster, 8, 16, RgtVinRequest.Empty()),
                new DataProvider(DataProviderName.LsaSpecifications, 9, 18, RgtRequestType.Empty())
            }, Guid.NewGuid());
        }

        public static IHavePackageForRequest RgtAndRgtVinPackage(string vinNumber)
        {
            return new LicensePlateNumberPackage(new IAmDataProvider[]
            {
                new DataProvider(DataProviderName.VinMaster, 8, 16, RgtVinRequest.WithVin(vinNumber)),
                new DataProvider(DataProviderName.LsaSpecifications, 9, 18, RgtRequestType.Empty())
            }, Guid.NewGuid());
        }
    }
}
