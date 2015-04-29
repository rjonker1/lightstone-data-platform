using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeStatisticsRepository : IReadOnlyRepository<Statistic>
    {

        public IEnumerable<Statistic> Get(string sql, object param)
        {
            return Builders.Sources.Lightstone.StatisticsDataBuilder.ForCarId_107483();
        }

        public IEnumerable<Statistic> GetAll(string sql)
        {
            throw new System.NotImplementedException();
        }
    }
}
