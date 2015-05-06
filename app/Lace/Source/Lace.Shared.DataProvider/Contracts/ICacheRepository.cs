using System.Collections.Generic;

namespace Lace.Shared.DataProvider.Contracts
{
    public interface ICacheRepository
    {
        void AddItems<TItem>(string sql, string cacheKey) where TItem : class;
        void AddItem<TItem>(string sql, object param, string cacheKey) where TItem : class;
        void Clear<TItem>(string cacheKey) where TItem : class;
        void ClearAll();
        IEnumerable<TItem> Get<TItem>(string cacheKey) where TItem : class;
    }
}
