using Lace.Models.Enums;
using Lace.Models.RgtVin.Dto;

namespace Lace.Source.Tests.Data.RgtVin
{
    public static class MockRgtVinResponseData
    {
        public static RgtVinResponse GetRgtVinResponseForLicensePlateNumber()
        {
            return new RgtVinResponse()
            {
                Colour = "Super White II",
                Month = 8,
                Price = 100000,
                Quarter = 4,
                RgtCode = 107483,
                ServiceProviderCallState = ServiceCallState.CallCompleted,
                VehicleMake = "TOYOTA",
                VehicleModel = "Auris 1.6 RT 5-dr",
                VehicleType = "Auris",
                Vin = "SB1KV58E40F039277",
                Year = 2008
            };
        }

        public static string GetRgtVinWebResponseForLicensePlateNumber()
        {
            return
                "#VIN|MAKE|TYPE|MODEL|YEAR|MONTH|QTR|RGTCODE|PRICE|COLOUR\n#SB1KV58E40F039277|TOYOTA|TOYOTA Auris|Auris 1.6 RT 5-dr|2008|8|3|107483|180100|Super White II";
        }
    }
}
