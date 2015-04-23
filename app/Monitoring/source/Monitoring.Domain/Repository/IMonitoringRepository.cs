using System.Collections.Generic;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Domain.Repository
{
    public interface IMonitoringRepository : IRepository
    {
        IList<TItem> Items<TItem>(string sql) where TItem : class;
    }
}
