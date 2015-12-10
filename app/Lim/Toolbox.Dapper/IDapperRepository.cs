using System.Collections.Generic;

namespace Toolbox.Dapper
{
    public interface IDapperRepository
    {
        IEnumerable<TObject> Get<TObject>(string sql) where TObject : class;
        IEnumerable<TObject> Get<TObject>(string sql, object param) where TObject : class;
        IEnumerable<dynamic> MultipleItems<TFirstResult, TSecondResult>(string sql, object param);
    }
}
