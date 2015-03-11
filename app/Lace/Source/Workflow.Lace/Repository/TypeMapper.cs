using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Workflow.Lace.Repository
{
    internal abstract class TypeMapper
    {
        protected abstract string TableName { get; }
        protected abstract IEnumerable<string> FieldNames { get; }

        protected string InsertStatement()
        {
            var values = FieldNames.Aggregate(string.Empty, (c, field) => c + string.Format("@{0}, ", field));
            values = values.Substring(0, values.Length - 2);

            var fields = FieldNames.Aggregate(string.Empty, (c, field) => c + string.Format("[{0}], ", field));
            fields = fields.Substring(0, fields.Length - 2);

            return string.Format("insert into [{0}] ({1}) values({2})", TableName, fields, values);
        }

        protected string SelectStatementWithId()
        {
            return string.Format("select * from [{0}] where id = @Id", TableName);
        }

        public abstract void Insert(IDbConnection connection, object instance);
        public abstract object Get(IDbConnection connection, Guid id);
    }
}
