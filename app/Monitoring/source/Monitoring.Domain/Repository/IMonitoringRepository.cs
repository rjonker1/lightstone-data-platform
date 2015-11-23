using System.Collections.Generic;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Domain.Repository
{
    public interface IMonitoringRepository : IRepository
    {
        IEnumerable<TItem> Items<TItem>(string sql) where TItem : class;
        IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class;
        SqlMapper.GridReader MultipleItems(string sql);
    }
}
