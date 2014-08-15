using System.Collections.Generic;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.DataObjects
{
    public class BaseLevelMetrics : IHaveBaseLevelMetrics
    {
        public IEnumerable<Statistics> StatisticsData { get; private set; }
    }
}
