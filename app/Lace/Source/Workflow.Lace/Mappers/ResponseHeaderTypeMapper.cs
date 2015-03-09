using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Repository;

namespace Workflow.Lace.Mappers
{
    internal class ResponseHeaderTypeMapper : TypeMapper
    {
        protected override string TableName
        {
            get { return "ResponseHeader"; }
        }

        protected override IEnumerable<string> FieldNames
        {
            get
            {
                return new[]
                {
                    "Id", "Date", "RequestId"
                };
            }
        }

        public override void Insert(System.Data.IDbConnection connection, object instance)
        {
            var response = (ResponseHeader) instance;
            var sql = InsertStatement();
            var values = new
            {
                Id = response.Response.Id,
                Date = response.Response.Date,
                RequestId = response.Response.RequestId
            };

            connection.Execute(sql, values);

        }

        public override object Get(System.Data.IDbConnection connection, Guid id)
        {
            var sql = SelectStatementWithId();
            var match = connection.Query(sql, new {Id = id}).FirstOrDefault();
            return match == null
                ? null
                : new ResponseHeader(new ResponseIdentifier(match.Id, match.RequestId, match.Date));
        }
    }
}
