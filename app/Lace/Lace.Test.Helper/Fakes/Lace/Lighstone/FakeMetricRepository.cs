using System;
using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeMetricRepository : IReadOnlyRepository<Metric>
    {
        public IEnumerable<Metric> Get(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Metric> GetAll(string sql)
        {
            return Builders.Sources.Lightstone.MetricDataBuilder.ForAllMetrics();
        }
    }
}
