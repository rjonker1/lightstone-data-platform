using System.Linq;

namespace Lace.Shared.DataProvider.Repositories
{
    public interface IReadOnlyRepository
    {
        IQueryable<TItem> GetAll<TItem>(string sql, string cacheKey) where TItem : class;
        IQueryable<TItem> Get<TItem>(string sql, object param, string cacheKey) where TItem : class;
        //TItem Item<TItem>(string sql, object param, string cacheKey) where TItem : class;
    }
}
