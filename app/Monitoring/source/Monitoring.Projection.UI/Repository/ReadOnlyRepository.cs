using System;
using System.Data;
using System.Linq;
using Monitoring.Domain.Core.Contracts;
using Monitoring.Projection.UI.Repository.Framework.Orm;

namespace Monitoring.Projection.UI.Repository
{
    public class ReadOnlyRepository : IQueryStorage
    {
        private readonly IDbConnection _connection;

        public ReadOnlyRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IQueryable<TItem> Items<TItem>() where TItem : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<TItem> Items<TItem>(string sql) where TItem : class
        {
            if (string.IsNullOrWhiteSpace(sql))
                throw new Exception("Sql Statement has not been provided");

            return _connection.Query<TItem>(sql).AsQueryable();
        }
    }
}