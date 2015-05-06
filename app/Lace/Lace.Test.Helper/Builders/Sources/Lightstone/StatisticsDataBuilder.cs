using System.Collections.Generic;
using Lace.Shared.DataProvider.Models;
using Lace.Test.Helper.Mothers.Sources.Lightstone;

namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class StatisticsDataBuilder
    {
        public static IEnumerable<Statistic> ForCarId_107483()
        {
            return StatisticsData.ForCarId();
        }
    }
}
