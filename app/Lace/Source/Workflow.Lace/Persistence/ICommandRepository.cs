using System.Collections.Generic;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Workflow.Lace.Persistence
{
    public interface ICommandRepository : IRepository
    {
        IList<TItem> Items<TItem>(string sql) where TItem : class;
        IList<TItem> Items<TItem>(string sql, object param) where TItem : class;
        TItem Item<TItem>(string sql, object param) where TItem : class;
    }
}
