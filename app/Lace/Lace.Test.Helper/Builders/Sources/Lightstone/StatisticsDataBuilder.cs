﻿using System.Collections.Generic;
using Lace.Test.Helper.Mothers.Sources.Lightstone;
using Lace.Toolbox.Database.Models;

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
