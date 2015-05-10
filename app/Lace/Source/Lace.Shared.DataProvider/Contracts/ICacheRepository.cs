
namespace Lace.Shared.DataProvider.Contracts
{
    public interface ICacheRepository
    {
        void AddItemsForEach<TItem>(string sql) where TItem : class;
        void AddItems<TItem>(string sql) where TItem : class;
        void ClearAll();
    }
}
