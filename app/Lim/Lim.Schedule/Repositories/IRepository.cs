using System.Collections.Generic;

namespace Lim.Schedule.Repositories
{
    public interface IRepository
    {
        IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class;
    }
}