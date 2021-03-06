﻿using System;
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
                        new DataProvider(DataProviderName.LSAutoCarStats_I_DB, 90, 92,
                            LightstoneAutoRequest.WithCarIdAndYear(carid, year), new BillableState(DataProviderNoRecordState.NonBillable))
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
                        new DataProvider(DataProviderName.LSAutoCarStats_I_DB, 90, 92,
                            LightstoneAutoRequest.WithVin(vinNumber), new BillableState(DataProviderNoRecordState.NonBillable))
                    }, Guid.NewGuid());
        }
    }

    public class CarIdPackage
    {
        public static IHavePackageForRequest CarIdDataPacakge(int carid, int year)
        {
            return
                new LicensePlateNumberPackage(
                    new IAmDataProvider[]
                    {
                        new DataProvider(DataProviderName.LSAutoCarStats_I_DB, 90, 92,
                            LightstoneAutoRequest.WithCarIdAndYear(carid, year), new BillableState(DataProviderNoRecordState.NonBillable)),
                        new DataProvider(DataProviderName.LSAutoSpecs_I_DB, 100, 200, RgtRequestType.Empty(),
                            new BillableState(DataProviderNoRecordState.NonBillable)),
                        new DataProvider(DataProviderName.MMCode_E_DB, 100, 200, MmCodeRequestType.Empty(),
                            new BillableState(DataProviderNoRecordState.NonBillable))
                    }, Guid.NewGuid());
        }
    }
}
