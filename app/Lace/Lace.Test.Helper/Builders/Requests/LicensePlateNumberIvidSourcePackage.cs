using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Requests
{

    public class LicensePlateNumberForceIvidToFailPackage
    {
        public static IHavePackageForRequest LicenseNumberPackage(string licensePlate, string packageName)
        {
            return new LicensePlateNumberPackage(
                new IAmDataProvider[]
                {
                    new DataProvider(DataProviderName.IVIDVerify_E_WS, 7, 14,
                        null, new BillableState(DataProviderNoRecordState.Billable)), 
                }, Guid.NewGuid());
        }
    }

    public class LicensePlateNumberIvidSourcePackage
    {
        public static IHavePackageForRequest LicenseNumberPackage(string licensePlate, string packageName)
        {
            return new LicensePlateNumberPackage(
                new IAmDataProvider[]
                {
                    new DataProvider(DataProviderName.IVIDVerify_E_WS, 7, 14,
                        new IvidStandardRequest(licensePlate, "Murray", packageName,
                            "murrayw@lightstone.co.za", "Murray", string.Empty), new BillableState(DataProviderNoRecordState.Billable))
                }, Guid.NewGuid());
        }

        public static IHavePackageForRequest LicenseNumberAndVinNumberPackage(string licensePlate, string vinNumber, string packageName)
        {
            return new LicensePlateNumberPackage(
                new IAmDataProvider[]
                {
                    new DataProvider(DataProviderName.IVIDVerify_E_WS, 7, 14,
                        new IvidLicenseAndVinRequest(licensePlate, "Murray", packageName,
                            "murrayw@lightstone.co.za", "Murray", string.Empty, vinNumber), new BillableState(DataProviderNoRecordState.Billable))
                }, Guid.NewGuid());
        }
    }


    public class VinNumberIvidSourcePackage
    {
        public static IHavePackageForRequest VinNumberPackage(string vinNumber, string packageName)
        {
            return new LicensePlateNumberPackage(
                new IAmDataProvider[]
                {
                    new DataProvider(DataProviderName.IVIDVerify_E_WS, 7, 14,
                        new IvidVinRequest(vinNumber, "Murray", packageName,
                            "murrayw@lightstone.co.za", "Murray", string.Empty), new BillableState(DataProviderNoRecordState.Billable))
                }, Guid.NewGuid());
        }
    }

    public class RegisterNumberIvidSourcePackage
    {
        public static IHavePackageForRequest RegisterNumberPackage(string registerNumber, string packageName)
        {
            return new LicensePlateNumberPackage(
                new IAmDataProvider[]
                {
                    new DataProvider(DataProviderName.IVIDVerify_E_WS, 7, 14,
                        new IvidRegisterNoRequest(registerNumber, "Murray", packageName,
                            "murrayw@lightstone.co.za", "Murray", string.Empty), new BillableState(DataProviderNoRecordState.Billable))
                }, Guid.NewGuid());
        }
    }
}
