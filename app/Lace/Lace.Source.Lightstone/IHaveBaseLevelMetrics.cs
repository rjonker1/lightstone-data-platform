using System.Collections.Generic;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone
{
    public interface IHaveBaseLevelMetrics
    {
        IEnumerable<Statistics> StatisticsData { get; }
        void BuildStatisticsData(IEnumerable<Statistics> statistics);
    }
}
