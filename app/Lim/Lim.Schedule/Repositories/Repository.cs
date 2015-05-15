using System.Collections.Generic;
using System.Data;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lim.Schedule.Repositories
{
    public class Repository : IRepository
    {
        private readonly IDbConnection _connection;

        public Repository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            return _connection.Query<TItem>(sql, param);
        }
    }
}