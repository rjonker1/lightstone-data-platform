using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicAndVinIvidLsAutPackage
    {
        public static IHavePackageForRequest LicenseNumberAndVinNumberPackage(string licensePlate, string vinNumber, string packageName)
        {
            return new LicensePlateNumberPackage(
                new IAmDataProvider[]
                {
                    new DataProvider(DataProviderName.IVIDVerify_E_WS, 7, 14,
                        new IvidLicenseAndVinRequest(licensePlate, "Murray", packageName,
                            "murrayw@lightstone.co.za", "Murray", string.Empty, vinNumber), new BillableState(DataProviderNoRecordState.Billable)),
                     new DataProvider(DataProviderName.LSAutoCarStats_I_DB, 90, 92,
                            LightstoneAutoRequest.WithVin(vinNumber), new BillableState(DataProviderNoRecordState.NonBillable))
                }, Guid.NewGuid());
        }
    }
}
