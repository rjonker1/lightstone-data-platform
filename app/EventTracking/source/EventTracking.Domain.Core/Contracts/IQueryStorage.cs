using System.Linq;

namespace EventTracking.Domain.Core.Contracts
{
    public interface IQueryStorage
    {
        IQueryable<TItem> Items<TItem>() where TItem : class;
    }
}
