namespace Monitoring.Domain.Core.Contracts
{
    using System.Linq;

    public interface IQueryStorage
    {
        IQueryable<TItem> Items<TItem>() where TItem : class;
        IQueryable<TItem> Items<TItem>(string sql) where TItem : class;
    }
}
