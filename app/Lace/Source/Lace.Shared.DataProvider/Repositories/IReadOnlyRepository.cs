using System;
using System.Linq;

namespace Lace.Shared.DataProvider.Repositories
{
    public interface IReadOnlyRepository
    {
        IQueryable<TItem> GetAll<TItem>(string sql) where TItem : class;
        IQueryable<TItem> Get<TItem>(string sql, object param) where TItem : class;
        IQueryable<TItem> GetAll<TItem>(string sql, Func<TItem, bool> predicate) where TItem : class;
        IQueryable<TItem> Get<TItem>(string sql, object param, Func<TItem, bool> predicate) where TItem : class;
    }
}
