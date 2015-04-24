using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
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
