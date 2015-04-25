using System.Collections.Generic;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Workflow.DataProvider.Bus.Domain.Repository
{
    public interface ICommandRepository : IRepository
    {
        IList<TItem> Items<TItem>(string sql) where TItem : class;
        IList<TItem> Items<TItem>(string sql, object param) where TItem : class;
    }
}
