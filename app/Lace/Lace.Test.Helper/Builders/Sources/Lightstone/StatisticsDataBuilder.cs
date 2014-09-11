using System.Collections.Generic;
using Lace.Source.Lightstone.Models;
using Lace.Test.Helper.Mothers.Sources.Lightstone;

namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class StatisticsDataBuilder
    {
        public static IEnumerable<Statistic> ForCarId_107483()
        {
            return StatisticsData.ForCarId();
        }

        public static IEnumerable<Statistic> ForMakeId_4()
        {
            return StatisticsData.ForMakeId();
        }
    }
}
