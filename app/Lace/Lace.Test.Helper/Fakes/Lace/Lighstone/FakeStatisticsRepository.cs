using System.Linq;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeStatisticsRepository : IReadOnlyRepository
    {
        public IQueryable<TItem> GetAll<TItem>(string sql, string cacheKey) where TItem : class
        {
            return (IQueryable<TItem>)Builders.Sources.Lightstone.StatisticsDataBuilder.ForCarId_107483().AsQueryable();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param, string cacheKey) where TItem : class
        {
            return (IQueryable<TItem>)Builders.Sources.Lightstone.StatisticsDataBuilder.ForCarId_107483().AsQueryable();
        }
    }

}
