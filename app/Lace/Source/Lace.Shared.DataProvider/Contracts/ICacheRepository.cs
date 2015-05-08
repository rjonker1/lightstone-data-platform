
namespace Lace.Shared.DataProvider.Contracts
{
    public interface ICacheRepository
    {
        void AddItems<TItem>(string sql) where TItem : class;
        void ClearAll();
    }
}
