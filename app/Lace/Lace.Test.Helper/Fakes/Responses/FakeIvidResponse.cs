using Lace.Source.Ivid.IvidServiceReference;

namespace Lace.Test.Helper.Fakes.Responses
{
    public static class FakeIvidResponse
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

        public static HpiStandardQueryResponse GetHpiStandardQueryResponseForLicenseNoSyb459Gp()
        {
            return new HpiStandardQueryResponse()
            {
                GVM = "1750",
                IvidReference = "IVD - 01468460493",
                category = new CodeDescription() { code = "B", description = "Light passenger mv(less than 12 persons)" },
                description = new CodeDescription() { code = "18", description = "Hatch back" },
                colour = new CodeDescription() { code = "3", description = "Silver" },
                driven = new CodeDescription() { code = "1", description = "Self-propelled" },
                economicSector = new CodeDescription() { code = "1", description = "Private" },
                engineDisplacement = "1598",
                engineNumber = "1404283",
                issuesTypes = null,
                ividQueryResult = IvidQueryResult.NO_ISSUES,
                licenceNumber = "SYB459GP",
                lifeStatus = new CodeDescription() { code = "2", description = "Used" },
                make = new CodeDescription() { code = "T05", description = "DAIHATSU" },
                model = new CodeDescription() { code = "D166", description = "Sirion" },
                partialResponse = false,
                partialResponseSpecified = false,
                registerNumber = "CNC407L",
                registrationDate = "2/18/2014",
                sapMark = new CodeDescription() { code = "99", description = "None" },
                tare = "1276",
                titleHolderIdNumber = null,
                titleHolderIdType = IdType.UNKNOWN,
                titleHolderIdTypeSpecified = false,
                vehicleStatusCode = VehicleState.LICENSED,
                vehicleStatusCodeSpecified = true,
                vin = "JDAM301S001019742"
            };
        }
    }
}
