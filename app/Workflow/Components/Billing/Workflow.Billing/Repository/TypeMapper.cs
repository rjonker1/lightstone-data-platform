using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Workflow.Billing.Repository
{
    internal abstract class TypeMapper
    {
        protected abstract string TableName { get; }
        protected abstract IEnumerable<string> FieldNames { get; }

        protected string GenerateInsertStatement()
        {
            var values = FieldNames.Aggregate(string.Empty, (current, fieldName) => current + string.Format("@{0}, ", fieldName));
            values = values.Substring(0, values.Length - 2);

            var fields = FieldNames.Aggregate(string.Empty, (current, fieldName) => current + string.Format("[{0}], ", fieldName));
            fields = fields.Substring(0, fields.Length - 2);

            return string.Format(@"INSERT INTO [{0}] ({1}) VALUES({2})", TableName, fields, values);
        }

        protected string GenerateSelectByIPrimaryKeyStatement()
        {
            return string.Format("SELECT * FROM [{0}] WHERE Id = @Id", TableName);
        }

        public abstract void Insert(IDbConnection connection, object instance);

        public abstract object Get(IDbConnection connection, Guid id);
    }
}