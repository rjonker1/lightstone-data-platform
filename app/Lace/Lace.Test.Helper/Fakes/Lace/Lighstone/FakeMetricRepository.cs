﻿
using System.Linq;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeMetricRepository : IReadOnlyRepository
    {
        public IQueryable<TItem> GetAll<TItem>(System.Func<TItem, bool> predicate) where TItem : class
        {
            return (IQueryable<TItem>)Builders.Sources.Lightstone.MetricDataBuilder.ForAllMetrics().AsQueryable();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            return (IQueryable<TItem>)Builders.Sources.Lightstone.MetricDataBuilder.ForAllMetrics().AsQueryable();
        }
    }
}
