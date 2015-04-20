using System.Data;
using System.Linq;
using Monitoring.Dashboard.UI.Infrastructure.Repository.Framework.Connection;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Dashboard.UI.Infrastructure.Repository
{

    //public interface ICommitRepository
    //{
    //    IQueryable<TItem> Items<TItem>(string sql) where TItem : class;
    //    IQueryable<TItem> Items<TItem>(string sql, object param) where TItem : class;
    //}

    //public class CommitRepository : CommonDomain.Persistence.IRepository
    //{
    //    private readonly IDbConnection _connection;

    //    public CommitRepository()
    //    {
    //        _connection = ConnectionFactory.ForCommandsDatabase();
    //    }

    //    public IQueryable<TItem> Items<TItem>(string sql) where TItem : class
    //    {
    //        return _connection.Query<TItem>(sql).ToList().AsQueryable();
    //    }


    //    public IQueryable<TItem> Items<TItem>(string sql, object param) where TItem : class
    //    {
    //        return _connection.Query<TItem>(sql, param).ToList().AsQueryable();
    //    }
    //}
}
