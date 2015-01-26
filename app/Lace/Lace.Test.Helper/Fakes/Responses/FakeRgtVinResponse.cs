using System.Collections.Generic;
using Lace.Domain.DataProviders.RgtVin.Core.Models;

namespace Lace.Test.Helper.Fakes.Responses
{
    public class FakeRgtVinResponse
    {
        public static List<Vin> GetRgtVinResponseForLicensePlateNumber()
        {
            return new List<Vin>
            {
                new Vin("SB1KV58E40F039277", 107483, "TOYOTA", "Auris", "Auris 1.6 RT 5-dr", 2008, "Third", 8,
                    "Super White II", "NAAMSA")
            };
        }
    }
}
