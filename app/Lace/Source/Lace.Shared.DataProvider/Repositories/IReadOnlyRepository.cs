using System;
using System.Collections.Generic;

namespace Lace.Toolbox.Database.Repositories
{
    public interface IReadOnlyRepository
    {
        IEnumerable<TItem> GetAll<TItem>(Func<TItem, bool> predicate) where TItem : class;
        IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class;
    }
}
