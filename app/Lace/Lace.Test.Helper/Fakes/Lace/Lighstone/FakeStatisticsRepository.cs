using System.Collections.Generic;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeStatisticsRepository : IReadOnlyRepository
    {
        public IEnumerable<TItem> GetAll<TItem>(System.Func<TItem, bool> predicate) where TItem : class
        {
            return (IEnumerable<TItem>)Builders.Sources.Lightstone.StatisticsDataBuilder.ForCarId_107483();
        }

        public IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            return (IEnumerable<TItem>)Builders.Sources.Lightstone.StatisticsDataBuilder.ForCarId_107483();
        }
    }
}