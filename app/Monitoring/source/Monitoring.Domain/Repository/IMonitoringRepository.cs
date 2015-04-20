using System.Linq;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Domain.Repository
{
    public interface IMonitoringRepository : IRepository
    {
        IQueryable<TItem> Items<TItem>(string sql) where TItem : class;
    }
}
