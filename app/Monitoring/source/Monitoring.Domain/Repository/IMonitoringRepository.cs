using System.Collections.Generic;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Domain.Repository
{
    public interface IMonitoringRepository : IRepository
    {
        IEnumerable<TItem> Items<TItem>(string sql) where TItem : class;
        IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class;
        IEnumerable<dynamic> MultipleItems<T1, T2, T3, T4>(string sql);
        //SqlMapper.GridReader MultipleItems(string sql);
    }
}
