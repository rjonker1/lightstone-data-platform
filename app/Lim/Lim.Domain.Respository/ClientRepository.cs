using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Common.Logging;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lim.Domain.Respository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _connection;
        private readonly ILog _log;

        public ClientRepository(IDbConnection connection)
        {
            _connection = connection;
            _log = LogManager.GetLogger(GetType());
        }

        public IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            try
            {
                return _connection.Query<TItem>(sql, param);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Could not get items from database because of {0}", ex.Message, ex);
            }

            return Enumerable.Empty<TItem>();
        }
    }
}
