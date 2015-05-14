using System.Collections.Generic;

namespace Lim.Domain.Respository
{
    public interface IReadOnlyRepository
    {
        IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class;
    }
}
