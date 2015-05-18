using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Common.Logging;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lim.Web.UI.Repository
{
    public class UserManangementRepository : IUserManagementRepository
    {
        private readonly IDbConnection _connection;
        private readonly ILog _log;
        public UserManangementRepository(IDbConnection connection)
        {
            _connection = connection;
            _log = LogManager.GetLogger(GetType());
        }
        public IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                return _connection.Query<TItem>(sql, param);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to retrieve information from the User Management database, because {0}", ex, ex.Message);
            }
            finally
            {
                _connection.Close();
            }

            return Enumerable.Empty<TItem>();
        }

        public TItem Item<TItem>(string sql, object param) where TItem : class
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                return _connection.Query<TItem>(sql, param).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to retrieve information from the User Management database, because {0}", ex, ex.Message);
            }
            finally
            {
                _connection.Close();
            }

            return Enumerable.Empty<TItem>().FirstOrDefault();
        }
    }
}