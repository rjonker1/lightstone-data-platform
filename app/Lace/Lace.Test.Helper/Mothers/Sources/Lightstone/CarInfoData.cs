using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Test.Helper.Mothers.Sources.Lightstone
{
    public class CarInfoData
    {
        public static IEnumerable<CarInfo> CarInformation()
        {
            return new List<CarInfo>()
            {
                new CarInfo(107483, 2008, "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg", "3rd Quarter",
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


        public static IEnumerable<KeyValuePair<string, CarInfo>> CarInformationWithVin()
        {
            return new Dictionary<string, CarInfo>()
            {
                {
                    "SB1KV58E40F039277",
                    new CarInfo(107483, 2008, "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg", "3rd Quarter",
                        "TOYOTA Auris 1.6 RT 5-dr", "Auris 1.6 RT 5-dr")
                },
                {
                    "WVWZZZ1KZAW208183",
                    new CarInfo(109031, 2010, "http://www.rgt.co.za/photos/VOLKSWAGEN/109031_1_P.jpg", "1st Quarter",
                        "VOLKSWAGEN Golf 6 2.0 GTI 5-dr DSG", "Golf 6 2.0 GTI 5-dr DSG")
                },
                {
                    "WAUZZZ8X8CB034633",
                    new CarInfo(110490, 2012, "http://www.rgt.co.za/photos/AUDI/110490_1_P.jpg", "1st Quarter",
                        "AUDI A1 1.2 FSI S 3-dr", "A1 1.2 FSI S 3-dr")
                },
                {
                    "KMHTC61DVDU136718",
                    new CarInfo(113018, 2013, "http://www.rgt.co.za/photos/HYUNDAI/113018_1_P.jpg", "2nd Quarter",
                        "HYUNDAI Veloster 1.6 GDI 3-dr Executive", "Veloster 1.6 GDI 3-dr Executive")
                }
            };
        }

        public static IEnumerable<KeyValuePair<string, CarInfo>> CarInformationFromVinShort()
        {
            return new Dictionary<string, CarInfo>()
            {
                {
                    "JDAM301S001019742",
                    new CarInfo(105253, 2004, "/images/Lightstone-auto-car.png", "Not Available",
                        "DAIHATSU Sirion 1.3 CX AT 5-dr", "Sirion 1.3 CX AT 5-dr")
                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105253, 2005, "/images/Lightstone-auto-car.png", "Not Available",
                        "DAIHATSU Sirion 1.3 CX AT 5-dr", "Sirion 1.3 CX AT 5-dr")
                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105254, 2004, "/images/Lightstone-auto-car.png", "Not Available",
                        "DAIHATSU Sirion 1.3 CXL 5-dr", "Sirion 1.3 CXL 5-dr")
                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105254, 2005, "/images/Lightstone-auto-car.png", "Not Available",
                        "DAIHATSU Sirion 1.3 CXL 5-dr", "Sirion 1.3 CXL 5-dr")
                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105526, 2005, "http://www.rgt.co.za/photos/DAIHATSU/105526_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 5-dr MY05", "Sirion 1.3 5-dr MY05")
                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105526, 2006, "http://www.rgt.co.za/photos/DAIHATSU/105526_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 5-dr MY05", "Sirion 1.3 5-dr MY05")
                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105526, 2007, "http://www.rgt.co.za/photos/DAIHATSU/105526_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 5-dr MY05", "Sirion 1.3 5-dr MY05")
                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105526, 2008, "http://www.rgt.co.za/photos/DAIHATSU/105526_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 5-dr MY05", "Sirion 1.3 5-dr MY05")

                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105527, 2005, "http://www.rgt.co.za/photos/DAIHATSU/105527_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 AT 5-dr MY05", "Sirion 1.3 AT 5-dr MY05")

                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105527, 2006, "http://www.rgt.co.za/photos/DAIHATSU/105527_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 AT 5-dr MY05", "Sirion 1.3 AT 5-dr MY05")

                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105527, 2007, "http://www.rgt.co.za/photos/DAIHATSU/105527_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 AT 5-dr MY05", "Sirion 1.3 AT 5-dr MY05")

                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105527, 2008, "http://www.rgt.co.za/photos/DAIHATSU/105527_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 AT 5-dr MY05", "Sirion 1.3 AT 5-dr MY05")

                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105528, 2005, "http://www.rgt.co.za/photos/DAIHATSU/105528_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 Sport 5-dr MY05", "Sirion 1.3 Sport 5-dr MY05")

                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105528, 2006, "http://www.rgt.co.za/photos/DAIHATSU/105528_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 Sport 5-dr MY05", "Sirion 1.3 Sport 5-dr MY05")

                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105528, 2007, "http://www.rgt.co.za/photos/DAIHATSU/105528_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 Sport 5-dr MY05", "Sirion 1.3 Sport 5-dr MY05")

                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105528, 2008, "http://www.rgt.co.za/photos/DAIHATSU/105528_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 Sport 5-dr MY05", "Sirion 1.3 Sport 5-dr MY05")

                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105529, 2005, "http://www.rgt.co.za/photos/DAIHATSU/105529_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 Sport AT 5-dr MY05", "Sirion 1.3 Sport AT 5-dr MY05")

                },
                {
                    "JDAM301S001019742",
                    new CarInfo(105529, 2006, "http://www.rgt.co.za/photos/DAIHATSU/105529_1_P.jpg", "Not Available",
                        "DAIHATSU Sirion 1.3 Sport AT 5-dr MY05", "Sirion 1.3 Sport AT 5-dr MY05")

                }
            };
        }
    }
}
