using System.Linq;

namespace Monitoring.Projection.UI.Core.Contracts.Repositories
{
    public interface IQueryStorage
    {
        IQueryable<TItem> Items<TItem>(string sql) where TItem : class;

        IQueryable<TItem> Items<TItem>(string sql, object param) where TItem : class;
    }
}
