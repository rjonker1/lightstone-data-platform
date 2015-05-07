
using System.Linq;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeMetricRepository : IReadOnlyRepository
    {
        public IQueryable<TItem> GetAll<TItem>(string sql, string cacheKey) where TItem : class
        {
            return (IQueryable<TItem>)Builders.Sources.Lightstone.MetricDataBuilder.ForAllMetrics().AsQueryable();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param, string cacheKey) where TItem : class
        {
            return (IQueryable<TItem>)Builders.Sources.Lightstone.MetricDataBuilder.ForAllMetrics().AsQueryable();
        }


        //public IEnumerable<Metric> Get(string sql, object param, string cacheKey)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Metric> GetAll(string sql, string cacheKey)
        //{
        //    return Builders.Sources.Lightstone.MetricDataBuilder.ForAllMetrics();
        //}
    }
}
