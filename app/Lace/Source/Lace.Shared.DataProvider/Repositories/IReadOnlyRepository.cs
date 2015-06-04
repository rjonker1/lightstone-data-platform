using System;
using System.Collections.Generic;

namespace Lace.Shared.DataProvider.Repositories
{
    public interface IReadOnlyRepository
    {
        //IQueryable<TItem> GetAll<TItem>(string sql) where TItem : class;
        //IQueryable<TItem> Get<TItem>(string sql, object param) where TItem : class;
        IEnumerable<TItem> GetAll<TItem>(Func<TItem, bool> predicate) where TItem : class;
        IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class;
    }
}
