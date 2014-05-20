﻿using Lace.Source.Ivid.IvidServiceReference;

namespace Lace.Source.Tests.Data.Ivid
{
    public static class MockIvidHpiStandardQueryResponseData
    {
        public static HpiStandardQueryResponse GetHpiStandardQueryResponseForLicenseNoXmc167Gp()
        {
            return new HpiStandardQueryResponse()
            {
                GVM = "1750",
                IvidReference = "IVD - 01468460493",
                category = new CodeDescription() { code = "B", description = "Light passenger mv(less than 12 persons)" },
                description = new CodeDescription() { code = "18", description = "Hatch back"},
                colour = new CodeDescription(){ code = "3", description = "White"},
                driven = new CodeDescription(){ code = "1", description = "Self-propelled"},
                economicSector = new CodeDescription(){ code = "1", description = "Private"},
                engineDisplacement = "1598",
                engineNumber = "1ZRU041295",
                issuesTypes = null,
                ividQueryResult = IvidQueryResult.NO_ISSUES,
                licenceNumber = "XMC167GP",
                lifeStatus = new CodeDescription(){ code = "2", description = "Used"},
                make = new CodeDescription(){ code = "T05", description = "Toyota"},
                model = new CodeDescription() { code = "D166", description = "AURIS"},
                partialResponse = false,
                partialResponseSpecified = false,
                registerNumber = "CNC407L",
                registrationDate = "2/18/2014",
                sapMark = new CodeDescription(){ code = "99", description = "None"},
                tare = "1276",
                titleHolderIdNumber = null,
                titleHolderIdType = IdType.UNKNOWN,
                titleHolderIdTypeSpecified = false,
                vehicleStatusCode = VehicleState.LICENSED,
                vehicleStatusCodeSpecified = true,
                vin = "SB1KV58E40F039277"
            };
        }
    }
}