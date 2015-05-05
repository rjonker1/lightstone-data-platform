namespace Lace.Shared.DataProvider.Contracts
{
    public interface ICacheRepository
    {
        void AddItems<TItem>(string sql, string cacheKey) where TItem : class;
        void AddItem<TItem>(string sql, object param, string cacheKey) where TItem : class;
        void Clear<TItem>(string cacheKey) where TItem : class;
        void ClearAll();
    }
}
