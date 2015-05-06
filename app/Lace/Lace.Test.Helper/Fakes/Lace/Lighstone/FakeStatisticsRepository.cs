using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Shared.DataProvider.Models;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeStatisticsRepository : IReadOnlyRepository<Statistic>
    {

        public IEnumerable<Statistic> Get(string sql, object param, string cacheKey)
        {
            return Builders.Sources.Lightstone.StatisticsDataBuilder.ForCarId_107483();
        }

        public IEnumerable<Statistic> GetAll(string sql, string cacheKey)
        {
            return Builders.Sources.Lightstone.StatisticsDataBuilder.ForCarId_107483();
        }
    }
}
