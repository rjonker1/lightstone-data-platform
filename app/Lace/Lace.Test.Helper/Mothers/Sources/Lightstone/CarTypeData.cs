using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Test.Helper.Mothers.Sources.Lightstone
{
    public class CarTypeData
    {
        public static IEnumerable<CarType> CarTypes()
        {
            return new List<CarType>()
            {
                new CarType(5,"ABARTH 500",2),
                new CarType(12, "ALFA 145", 4),
                new CarType(13, "ALFA 146", 4),
                new CarType(14, "ALFA 147", 4),
                new CarType(15, "ALFA 155", 4),
                new CarType(16, "ALFA 156", 4),
                new CarType(17, "ALFA 159", 4),
                new CarType(18, "ALFA 164", 4),
                new CarType(19, "ALFA 166", 4),
                new CarType(20, "ALFA Brera", 4),
                new CarType(21, "ALFA Giulietta", 4),
                new CarType(22, "ALFA GT", 4),
                new CarType(23, "ALFA GTV", 4),
                new CarType(24, "ALFA MiTo", 4),
                new CarType(25, "ALFA Spider", 4),
                new CarType(26, "AM DB7", 6),
                new CarType(27, "AM DB9", 6),
                new CarType(28, "AM DBS", 6),
                new CarType(29, "AM Vanquish", 6),
                new CarType(30, "AM Vantage", 6),
                new CarType(31, "AM Virage", 6),
                new CarType(32, "ASIAWING 2500", 5),
                new CarType(33, "ASIAWING 3300", 5),
                new CarType(34, "AUDI 500", 7),
                new CarType(35, "AUDI A1", 7),
                new CarType(36, "AUDI A1 Sportback", 7),
                new CarType(37, "AUDI A3", 7),
                new CarType(38, "AUDI A3 Sportback", 7),
                new CarType(39, "AUDI A4", 7),
                new CarType(40, "AUDI A4 Allroad", 7),
                new CarType(41, "AUDI A4 Avant", 7),
                new CarType(42, "AUDI A5 Coupe/Cabriolet", 7),
                new CarType(43, "AUDI A5 Sportback", 7),
                new CarType(44, "AUDI A6", 7),
                new CarType(45, "AUDI A6 Allroad", 7),
                new CarType(46, "AUDI A6 Avant", 7),
                new CarType(47, "AUDI A7 Sportback", 7),
                new CarType(48, "AUDI A8", 7),
                new CarType(49, "AUDI Q3", 7),
                new CarType(50, "AUDI Q5", 7),
                new CarType(51, "AUDI Q7", 7),
                new CarType(52, "AUDI R8", 7),
                new CarType(53, "AUDI TT", 7),
            };
        }
    }
}
