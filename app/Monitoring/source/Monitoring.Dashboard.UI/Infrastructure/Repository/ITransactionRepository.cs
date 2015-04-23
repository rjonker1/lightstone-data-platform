using System.Collections.Generic;
using System.Data;
using System.Linq;
using Monitoring.Dashboard.UI.Infrastructure.Repository.Framework.Connection;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Dashboard.UI.Infrastructure.Repository
{
    public interface ITransactionRepository
    {
        IList<TItem> Items<TItem>(string sql) where TItem : class;
        IList<TItem> Items<TItem>(string sql, object param) where TItem : class;
    }

    public class BillingTransactionRepository : ITransactionRepository
    {
        private readonly IDbConnection _connection;

        public BillingTransactionRepository()
        {
            _connection = ConnectionFactory.ForBillingDatabase();  
        }

        public IList<TItem> Items<TItem>(string sql) where TItem : class
        {
            return _connection.Query<TItem>(sql).ToList();
        }

        public IList<TItem> Items<TItem>(string sql, object param) where TItem : class
        {
            return _connection.Query<TItem>(sql, param).ToList();
        }
    }
}
