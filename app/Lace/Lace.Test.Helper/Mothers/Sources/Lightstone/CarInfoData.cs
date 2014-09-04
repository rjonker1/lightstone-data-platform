using System.Collections.Generic;
using Lace.Source.Lightstone.Models;

namespace Lace.Test.Helper.Mothers.Sources.Lightstone
{
    public class CarInfoData
    {
        public static IEnumerable<CarInfo> CarInformation()
        {
            return new List<CarInfo>()
            {
                new CarInfo(107483, 2008, "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg", "Third",
                    "TOYOTA Auris 1.6 RT 5-dr", "Auris 1.6 RT 5-dr")
            };
        }

        public static IEnumerable<CarInfo> CarInforamtionForVin12()
        {
            return new List<CarInfo>()
            {
                new CarInfo(107483, 2007, "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg", "Not Available",
                    "TOYOTA Auris 1.6 RT 5-dr", "Auris 1.6 RT 5-dr"),
                new CarInfo(107483, 2008, "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg", "Not Available",
                    "TOYOTA Auris 1.6 RT 5-dr", "Auris 1.6 RT 5-dr"),
                new CarInfo(107483, 2009, "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg", "Not Available",
                    "TOYOTA Auris 1.6 RT 5-dr", "Auris 1.6 RT 5-dr")
            };
        }
    }
}
