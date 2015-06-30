using System;

namespace Lace.Domain.Core.Contracts.Caching
{
    public interface ICacheRepository
    {
        void AddItemsForEach<TItem>(string sql) where TItem : class;
        void AddItems<TItem>(string sql) where TItem : class;
        void AddItemWithKey<TItem>(string key, TItem item, DateTime expiresAt) where TItem : class;
        void ClearAll();
    }
}
