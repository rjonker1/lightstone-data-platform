using System.Collections.Generic;

namespace Lim.Domain.Repository
{
    public interface ILimRepository
    {
        IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class;
        TItem Item<TItem>(string sql, object param) where TItem : class;
        void Add(string sql, object param);
    }

    public interface IUserManagementRepository
    {
        IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class;
        TItem Item<TItem>(string sql, object param) where TItem : class;
    }

    public interface IRepository
    {
        IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class;
    }
}