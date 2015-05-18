﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Common.Logging;
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
        private readonly IDbConnection _connection;
        private readonly ILog _log;

        public BillingTransactionRepository(IDbConnection connection)
        {
            _connection = connection;
            _log = LogManager.GetLogger(GetType());
        }

        public IEnumerable<TItem> Items<TItem>(string sql) where TItem : class
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                return _connection.Query<TItem>(sql);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to retrieve information from the Billing database, because {0}", ex, ex.Message);
            }
            finally
            {
                _connection.Close();
            }

            return Enumerable.Empty<TItem>();
        }

        public IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                return _connection.Query<TItem>(sql, param).ToList();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to retrieve information from the Billing database, because {0}", ex, ex.Message);
            }
            finally
            {
                _connection.Close();
            }

            return Enumerable.Empty<TItem>();
        }
    }
}
