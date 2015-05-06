using System;
using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Shared.DataProvider.Models;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeMetricRepository : IReadOnlyRepository<Metric>
    {
        public IEnumerable<Metric> Get(string sql, object param, string cacheKey)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Metric> GetAll(string sql, string cacheKey)
        {
            return Builders.Sources.Lightstone.MetricDataBuilder.ForAllMetrics();
        }
    }
}
