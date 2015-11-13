using System;
using System.Collections.Generic;
using Lace.Toolbox.Database.Dtos;

namespace Lace.Test.Helper.Mothers.Sources.Lightstone
{
    public class CarInfoData
    {
        public static IEnumerable<CarInformationDto> CarInformation()
        {
            return new List<CarInformationDto>()
            {
                new CarInformationDto(107483, 2008, 862, 59, "TOYOTA Auris 1.6 RT 5-dr", "Auris 1.6 RT 5-dr",
                    "Hatch (5-dr)",
                    "Petrol", "PAS", "Man", 2007, DateTime.Now.ToShortDateString(),
                    "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg", "Not Available", 98)
            };
        }

        //public static IEnumerable<CarInformationDto> CarInforamtionForVin12()
        //{
        //    return new List<CarInformationDto>()
        //    {
        //        new CarInformationDto(107483, 2007, "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg", "Not Available",
        //            "TOYOTA Auris 1.6 RT 5-dr", "Auris 1.6 RT 5-dr"),
        //        new CarInformationDto(107483, 2008, "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg", "Not Available",
        //            "TOYOTA Auris 1.6 RT 5-dr", "Auris 1.6 RT 5-dr"),
        //        new CarInformationDto(107483, 2009, "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg", "Not Available",
        //            "TOYOTA Auris 1.6 RT 5-dr", "Auris 1.6 RT 5-dr")
        //    };
        //}


        public static IEnumerable<KeyValuePair<string, CarInformationDto>> CarInformationWithVin()
        {
            return new Dictionary<string, CarInformationDto>()
            {
                {
                    "SB1KV58E40F039277",
                    new CarInformationDto(107483, 2008, 862, 59, "TOYOTA Auris 1.6 RT 5-dr", "Auris 1.6 RT 5-dr",
                        "Hatch (5-dr)", "Petrol", "PAS", "Man", 2007, DateTime.Now.ToShortDateString(),
                        "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg", "3rd Quarter", 98)
                },
                {
                    "WVWZZZ1KZAW208183",
                    new CarInformationDto(109031, 2010, 953, 62, "VOLKSWAGEN Golf 6 2.0 GTI 5-dr DSG",
                        "Golf 6 2.0 GTI 5-dr DSG", "Hatch (5-dr)", "Petrol", "PAS", "Elec", 2009,
                        DateTime.Now.ToShortDateString(), "http://www.rgt.co.za/photos/VOLKSWAGEN/109031_1_P.jpg",
                        "1st Quarter", 102)
                },
                {
                    "WAUZZZ8X8CB034633",
                    new CarInformationDto(110490, 2012, 40, 62, "AUDI A1 1.2 FSI S 3-dr", "A1 1.2 FSI S 3-dr",
                        "Hatch (3-dr)", "Petrol", "PAS", "Man", 2011, DateTime.Now.ToShortDateString(),
                        "http://www.rgt.co.za/photos/AUDI/110490_1_P.jpg", "1st Quarter", 7)
                },
                {
                    "KMHTC61DVDU136718",
                    new CarInformationDto(113018, 2013, 384, 3, "HYUNDAI Veloster 1.6 GDI 3-dr Executive",
                        "Veloster 1.6 GDI 3-dr Executive", "Hatch (3-dr)", "Petrol", "PAS", "Man", 2013,
                        DateTime.Now.ToShortDateString(), "http://www.rgt.co.za/photos/HYUNDAI/113018_1_P.jpg",
                        "2nd Quarter", 47)
                }
            };
        }

        public static IEnumerable<KeyValuePair<string, CarInformationDto>> CarInformationFromVinShort()
        {
            return new Dictionary<string, CarInformationDto>()
            {
                {
                    "JDAM301S001019742",
                    new CarInformationDto(106852, 0, 175, 3, "DAIHATSU Sirion 1.3 DRD 5-dr", "Sirion 1.3 DRD 5-dr",
                        "Hatch (5-dr)", "Petrol", "PAS", "Man", 2006, DateTime.Now.ToShortDateString(),
                        "/images/Lightstone-auto-car.png", "Not Available", 24)
                },
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(105252, 2015, 175, 3, "DAIHATSU Sirion 1.3 CX 5-dr", "Sirion 1.3 CX 5-dr",
                //        "Hatch (5-dr)", "Petrol", "PAS", "Man", 2004, DateTime.Now.ToShortDateString(),
                //        "/images/Lightstone-auto-car.png", "Not Available", 24)
                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(105254, 2015, 175, 3, "DAIHATSU Sirion 1.3 CXL 5-dr", "Sirion 1.3 CXL 5-dr",
                //        "Hatch (5-dr)", "Petrol", "PAS", "Man", 2004, DateTime.Now.ToShortDateString(),
                //        "/images/Lightstone-auto-car.png", "Not Available", 24)
                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(105253, 2005, 175, 3, "DAIHATSU Sirion 1.3 CX AT 5-dr", "Sirion 1.3 CX AT 5-dr",
                //        "Hatch (5-dr)", "Petrol", "PAS", "Auto", 2004, DateTime.Now.ToShortDateString(),
                //        "/images/Lightstone-auto-car.png", "Not Available", 24)
                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(105526, 2007, 175, 3, "DAIHATSU Sirion 1.3 5-dr MY05", "Sirion 1.3 5-dr MY05",
                //        "Hatch (5-dr)", "Petrol", "PAS", "Man", 2005, DateTime.Now.ToShortDateString(),
                //        "http://www.rgt.co.za/photos/DAIHATSU/105526_1_P.jpg", "Not Available", 24)
                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(105527, 3, 175, 3, "DAIHATSU Sirion 1.3 AT 5-dr MY05", "Sirion 1.3 AT 5-dr MY05",
                //        "Hatch (5-dr)", "Petrol", "PAS", "Auto", 2005, DateTime.Now.ToShortDateString(),
                //        "http://www.rgt.co.za/photos/DAIHATSU/105527_1_P.jpg", "Not Available", 24)
                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(108149, 7, 175, 3, "DAIHATSU Sirion 1.3 5-dr MY07", "Sirion 1.3 5-dr MY07",
                //        "Hatch (5-dr)", "Petrol", "PAS", "Man", 2007, DateTime.Now.ToShortDateString(),
                //        "http://www.rgt.co.za/photos/DAIHATSU/108149_1_P.jpg", "Not Available", 24)
                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(105529, 2007, 175, 3, "DAIHATSU Sirion 1.3 Sport AT 5-dr MY05",
                //        "Sirion 1.3 Sport AT 5-dr MY05", "Hatch (5-dr)", "Petrol", "PAS", "Auto", 2005,
                //        DateTime.Now.ToShortDateString(), "http://www.rgt.co.za/photos/DAIHATSU/105529_1_P.jpg",
                //        "Not Available", 24)

                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(105528, 2005, 175, 3, "DAIHATSU Sirion 1.3 Sport 5-dr MY05",
                //        "Sirion 1.3 Sport 5-dr MY05", "Hatch (5-dr)", "Petrol", "PAS", "Man", 2005,
                //        DateTime.Now.ToShortDateString(), "http://www.rgt.co.za/photos/DAIHATSU/105528_1_P.jpg",
                //        "Not Available", 24)

                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(105529, 2008, 175, 3, "DAIHATSU Sirion 1.3 Sport AT 5-dr MY05",
                //        "Sirion 1.3 Sport AT 5-dr MY05", "Hatch (5-dr)", "Petrol", "PAS", "Auto", 2005,
                //        DateTime.Now.ToShortDateString(), "http://www.rgt.co.za/photos/DAIHATSU/105529_1_P.jpg",
                //        "Not Available", 24)

                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(105527, 2008, 175, 3, "DAIHATSU Sirion 1.3 AT 5-dr MY05",
                //        "Sirion 1.3 AT 5-dr MY05", "Hatch (5-dr)", "Petrol", "PAS", "Auto", 2005,
                //        DateTime.Now.ToShortDateString(), "http://www.rgt.co.za/photos/DAIHATSU/105527_1_P.jpg",
                //        "Not Available", 24)

                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(105528, 2008, 175, 3, "DAIHATSU Sirion 1.3 Sport 5-dr MY05",
                //        "Sirion 1.3 Sport 5-dr MY05", "Hatch (5-dr)", "Petrol", "PAS", "Man", 2005,
                //        DateTime.Now.ToShortDateString(), "http://www.rgt.co.za/photos/DAIHATSU/105528_1_P.jpg",
                //        "Not Available", 24)

                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(108150, 2009, 175, 3, "DAIHATSU Sirion 1.3 5-dr MY07 AT",
                //        "Sirion 1.3 5-dr MY07 AT", "Hatch (5-dr)", "Petrol", "PAS", "Auto", 2007,
                //        DateTime.Now.ToShortDateString(), "http://www.rgt.co.za/photos/DAIHATSU/108150_1_P.jpg",
                //        "Not Available", 24)

                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(105526, 2008, 175, 3, "DAIHATSU Sirion 1.3 5-dr MY05", "Sirion 1.3 5-dr MY05",
                //        "Hatch (5-dr)", "Petrol", "PAS", "Man", 2005, DateTime.Now.ToShortDateString(),
                //        "http://www.rgt.co.za/photos/DAIHATSU/105526_1_P.jpg", "Not Available", 24)

                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(105526, 2008, 175, 3, "DAIHATSU Sirion 1.3 5-dr MY05", "Sirion 1.3 5-dr MY05",
                //        "Hatch (5-dr)", "Petrol", "PAS", "Man", 2005, DateTime.Now.ToShortDateString(),
                //        "http://www.rgt.co.za/photos/DAIHATSU/105526_1_P.jpg", "Not Available", 24)

                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(107725, 2011, 175, 3, "DAIHATSU Sirion 1.5 Sport 5-dr", "Sirion 1.5 Sport 5-dr",
                //        "Hatch (5-dr)", "Petrol", "PAS", "Man", 2007, DateTime.Now.ToShortDateString(),
                //        "http://www.rgt.co.za/photos/DAIHATSU/107725_1_P.jpg", "Not Available", 24)

                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(108150, 2011, 175, 3, "DAIHATSU Sirion 1.3 5-dr MY07 AT",
                //        "Sirion 1.3 5-dr MY07 AT", "Hatch (5-dr)", "Petrol", "PAS", "Auto", 2007,
                //       DateTime.Now.ToShortDateString(), "http://www.rgt.co.za/photos/DAIHATSU/108150_1_P.jpg",
                //        "Not Available", 24)

                //},
                //{
                //    "JDAM301S001019742",
                //    new CarInformationDto(108150, 2009, 175, 3, "DAIHATSU Sirion 1.3 5-dr MY07 AT",
                //        "Sirion 1.3 5-dr MY07 AT", "Hatch (5-dr)", "Petrol", "PAS", "Auto", 2007,
                //        DateTime.Now.ToShortDateString(), "http://www.rgt.co.za/photos/DAIHATSU/108150_1_P.jpg",
                //        "Not Available", 24)

                //}
            };
        }
    }
}
