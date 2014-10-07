using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class MetricDataBuilder
    {
        public static IEnumerable<Metric> ForAllMetrics()
        {
            return Mothers.Sources.Lightstone.MetricData.AllMetrics();
        }
    }
}
