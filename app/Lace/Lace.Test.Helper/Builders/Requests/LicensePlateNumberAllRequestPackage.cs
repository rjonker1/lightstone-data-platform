﻿using System;
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
                new DataProvider(DataProviderName.IVIDVerify_E_WS, 5, 10,
                    new IvidStandardRequest(licensePlate, "Murray", packageName,
                        "murrayw@lightstone.co.za", "Murray", string.Empty), new BillableState(DataProviderNoRecordState.Billable)),
                new DataProvider(DataProviderName.LSAutoCarStats_I_DB, 6, 12, LightstoneAutoRequest.Empty(), new BillableState(DataProviderNoRecordState.Billable)),
                new DataProvider(DataProviderName.IVIDTitle_E_WS, 7, 14,
                    IvidTitleHolderRequest.WithVin(null, "murrayw@lightstone.co.za", "Murray"), new BillableState(DataProviderNoRecordState.Billable)),
                new DataProvider(DataProviderName.LSAutoVINMaster_I_DB, 8, 16, RgtVinRequest.Empty(), new BillableState(DataProviderNoRecordState.NonBillable)),
                new DataProvider(DataProviderName.LSAutoSpecs_I_DB, 9, 18, RgtRequestType.Empty(), new BillableState(DataProviderNoRecordState.NonBillable))
            }, Guid.NewGuid());
        }
        public static IHavePackageForRequest LicenseNumberPackage(string licensePlate, string packageName)
        {
            return new LicensePlateNumberPackage(new IAmDataProvider[]
            {
                new DataProvider(DataProviderName.IVIDVerify_E_WS, 5, 10,
                    new IvidStandardRequest(licensePlate, "Murray", packageName,
                        "murrayw@lightstone.co.za", "Murray", string.Empty), new BillableState(DataProviderNoRecordState.Billable)),
                new DataProvider(DataProviderName.LSAutoCarStats_I_DB, 6, 12, LightstoneAutoRequest.Empty(), new BillableState(DataProviderNoRecordState.NonBillable)),
                new DataProvider(DataProviderName.IVIDTitle_E_WS, 7, 14,
                    IvidTitleHolderRequest.WithVin(null, "murrayw@lightstone.co.za", "Murray"), new BillableState(DataProviderNoRecordState.Billable)),
                new DataProvider(DataProviderName.LSAutoVINMaster_I_DB, 8, 16, RgtVinRequest.Empty(), new BillableState(DataProviderNoRecordState.NonBillable)),
                new DataProvider(DataProviderName.LSAutoSpecs_I_DB, 9, 18, RgtRequestType.Empty(), new BillableState(DataProviderNoRecordState.NonBillable)) 
            }, Guid.NewGuid());
        }

        public static IHavePackageForRequest LicensePlateIvidRgtVinAndMmCodePackage(string licensePlate, string packageName)
        {
            return new LicensePlateNumberPackage(new IAmDataProvider[]
            {
                new DataProvider(DataProviderName.IVIDVerify_E_WS, 5, 10,
                    new IvidStandardRequest(licensePlate, "Murray", packageName,
                        "murrayw@lightstone.co.za", "Murray", string.Empty), new BillableState(DataProviderNoRecordState.Billable)),
                new DataProvider(DataProviderName.LSAutoVINMaster_I_DB, 8, 16, RgtVinRequest.Empty(), new BillableState(DataProviderNoRecordState.NonBillable)),
                new DataProvider(DataProviderName.MMCode_E_DB, 9, 18, MmCodeRequestType.Empty(), new BillableState(DataProviderNoRecordState.NonBillable)) 
            }, Guid.NewGuid());
        }
    }

    public class VinNumberRequestPackage
    {
        public static IHavePackageForRequest LsAutoRgtAndRgitVinPackage(string vinNumber)
        {
            return new LicensePlateNumberPackage(new IAmDataProvider[]
            {
                new DataProvider(DataProviderName.LSAutoCarStats_I_DB, 6, 12, LightstoneAutoRequest.WithVin(vinNumber), new BillableState(DataProviderNoRecordState.NonBillable)),
                new DataProvider(DataProviderName.LSAutoVINMaster_I_DB, 8, 16, RgtVinRequest.Empty(), new BillableState(DataProviderNoRecordState.NonBillable)),
                new DataProvider(DataProviderName.LSAutoSpecs_I_DB, 9, 18, RgtRequestType.Empty(), new BillableState(DataProviderNoRecordState.NonBillable))
            }, Guid.NewGuid());
        }

        public static IHavePackageForRequest RgtAndRgtVinPackage(string vinNumber)
        {
            return new LicensePlateNumberPackage(new IAmDataProvider[]
            {
                new DataProvider(DataProviderName.LSAutoVINMaster_I_DB, 8, 16, RgtVinRequest.WithVin(vinNumber), new BillableState(DataProviderNoRecordState.NonBillable)),
                new DataProvider(DataProviderName.LSAutoSpecs_I_DB, 9, 18, RgtRequestType.Empty(), new BillableState(DataProviderNoRecordState.NonBillable))
            }, Guid.NewGuid());
        }
    }
}
