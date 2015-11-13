using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberMmCodeRequestPackage
    {
        public static IHavePackageForRequest LicenseNumberPackage(int carId)
        {
            return
                new LicensePlateNumberPackage(
                    new IAmDataProvider[] { new DataProvider(DataProviderName.MMCode_E_DB, 17, 33, MmCodeRequestType.WithCarId(carId.ToString()), new BillableState(DataProviderNoRecordState.Billable)) },
                    Guid.NewGuid());
        }
    }
}