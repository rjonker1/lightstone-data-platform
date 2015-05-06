using System.Collections.Generic;
using Lace.Shared.DataProvider.Models;

namespace Lace.Test.Helper.Mothers.Sources.Lightstone
{
    public class BandData
    {
        public static IEnumerable<Band> AllBands()
        {
            return new List<Band>()
            {
                new Band(0, "None", 0, 0),
                new Band(2, "Under 25", 6, 0),
                new Band(3, "> 25 to 34", 6, 0),
                new Band(4, "> 34 to 44", 6, 0),
                new Band(5, "> 44 to 54", 6, 0),
                new Band(6, ">54 to 64", 6, 0),
                new Band(7, ">64", 6, 0),
                new Band(8, "Female", 7, 0),
                new Band(9, "Male", 7, 0),
                new Band(10, "Front", 4, 0),
                new Band(11, "Side", 4, 0),
                new Band(12, "Rear", 4, 0),
                new Band(13, "p1", 5, 0),
                new Band(14, "p5", 5, 0),
                new Band(15, "p10", 5, 0),
                new Band(16, "p25", 5, 0),
                new Band(17, "p50", 5, 0),
                new Band(18, "p75", 5, 0),
                new Band(19, "p90", 5, 0),
                new Band(20, "p95", 5, 0),
                new Band(21, "p99", 5, 0),
                new Band(22, "0", 14, 0),
                new Band(23, "1", 14, 0),
                new Band(24, "2", 14, 0),
                new Band(25, "3", 14, 0),
                new Band(26, "4", 14, 0),
                new Band(27, "5", 14, 0),
                new Band(28, "6", 14, 0),
                new Band(29, "7", 14, 0),
                new Band(30, "8", 14, 0),
                new Band(31, "9", 14, 0),
                new Band(32, "10", 14, 0),
                new Band(44, "Front Index", 22, 0),
                new Band(45, "Side Index", 22, 0),
                new Band(46, "Rear Index", 22, 0),
                new Band(47, "Weighted Index", 22, 0),
                new Band(48, "Subject", 23, 0),
                new Band(49, "Lower Bound", 23, 0),
                new Band(50, "Upper Bound", 23, 0),
                new Band(51, "Quartile", 23, 0),
                new Band(52, "> 22500kg", 19, 0),
                new Band(53, "12001-15000kg", 19, 0),
                new Band(54, "15001-16500kg", 19, 0),
                new Band(55, "16501-22500kg", 19, 0),
                new Band(56, "3501-8500kg Bus", 19, 0),
                new Band(57, "3501-8500kg FC", 19, 0),
                new Band(58, "3501-8500kg Panel Van", 19, 0),
                new Band(59, "3501-8500kg Tipper", 19, 0),
                new Band(60, "8501-12000kg", 19, 0),
                new Band(61, "A - Entry", 19, 0),
                new Band(62, "AB - sub-Small", 19, 0),
                new Band(63, "Above One-Ton DCab", 19, 0),
                new Band(64, "Above One-Ton SCab", 19, 0),
                new Band(65, "Above One-Ton XCab", 19, 0),
                new Band(66, "B - Small", 19, 0),
                new Band(67, "Bus > 8500kg", 19, 0),
                new Band(68, "C - Medium", 19, 0),
                new Band(69, "D - Large", 19, 0),
                new Band(70, "E - Luxury", 19, 0),
                new Band(71, "F - MPV", 19, 0),
                new Band(72, "G - SUV", 19, 0),
                new Band(73, "Minibus", 19, 0),
                new Band(74, "Panel Van", 19, 0),
                new Band(75, "SE - Sport and Exotics", 19, 0),
                new Band(76, "Sub One-Ton", 19, 0),
                new Band(77, "X - Crossover", 19, 0)
            };
        }
    }
}
