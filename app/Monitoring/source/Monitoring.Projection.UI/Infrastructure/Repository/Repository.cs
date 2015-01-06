using System.Data;
using System.Linq;
using Monitoring.Projection.UI.Core.Contracts.Repositories;
using Monitoring.Projection.UI.Infrastructure.Repository.Framework.Orm;

namespace Monitoring.Projection.UI.Infrastructure.Repository
{
    public class Repository : IQueryStorage
    {
        private readonly IDbConnection _connection;

        public Repository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IQueryable<TItem> Items<TItem>(string sql) where TItem : class
        {
            return _connection.Query<TItem>(sql).ToList().AsQueryable();
        }

        public IQueryable<TItem> Items<TItem>(string sql, object param) where TItem : class
        {
            return _connection.Query<TItem>(sql, param).ToList().AsQueryable();
        }
    }
}