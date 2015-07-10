using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Monitoring.Domain.Repository;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Dashboard.UI.Infrastructure.Repository
{
    public interface ITransactionRepository
    {
        IEnumerable<TItem> Items<TItem>(string sql) where TItem : class;
        IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class;
    }

    public class BillingTransactionRepository : ITransactionRepository
    {
        private readonly ILog _log;

        public BillingTransactionRepository()
        {
            _log = LogManager.GetLogger(GetType());
        }

        public IEnumerable<TItem> Items<TItem>(string sql) where TItem : class
        {
            try
            {
                using (var connection = ConnectionFactoryManager.BillingConnection)
                    return connection.Query<TItem>(sql);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to retrieve information from the Billing database, because {0}", ex, ex.Message);
            }

            return Enumerable.Empty<TItem>();
        }

        public IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class
        {
            try
            {
                using (var connection = ConnectionFactoryManager.BillingConnection)
                    return connection.Query<TItem>(sql, param).ToList();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to retrieve information from the Billing database, because {0}", ex, ex.Message);
            }

            return Enumerable.Empty<TItem>();
        }
    }
}