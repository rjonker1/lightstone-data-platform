using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Toolbox.Dapper
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IDbConnection _connection;

        public DapperRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TObject> Get<TObject>(string sql, object param) where TObject : class
        {
            return _connection.Query<TObject>(sql, param);
        }

        public IEnumerable<dynamic> MultipleItems<TFirstResult, TSecondResult>(string sql, object param)
        {
            var results = _connection.QueryMultiple(sql, param);
            var returnResult = new List<dynamic>()
                    {
                        results.Read<TFirstResult>().ToList(),
                        results.Read<TSecondResult>().ToList()
                    };
            return returnResult;
        }
        public IEnumerable<TObject> Get<TObject>(string sql) where TObject : class
        {
            return _connection.Query<TObject>(sql);
        }
    }
}