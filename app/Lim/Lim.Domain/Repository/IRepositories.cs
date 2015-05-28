using System.Collections.Generic;

namespace Lim.Domain.Repository
{
    public interface IReadLimRepository
    {
        IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class;
        TItem Item<TItem>(string sql, object param) where TItem : class;
    }

    public interface IReadUserManagementRepository
    {
        IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class;
        TItem Item<TItem>(string sql, object param) where TItem : class;
    }
}