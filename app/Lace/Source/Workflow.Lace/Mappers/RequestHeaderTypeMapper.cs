using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Identifiers;
using Workflow.Lace.Domain;
using Workflow.Lace.Repository;

namespace Workflow.Lace.Mappers
{
    internal class RequestHeaderTypeMapper : TypeMapper
    {
        protected override string TableName
        {
            get { return "RequestHeader"; }
        }

        protected override IEnumerable<string> FieldNames
        {
            get
            {
                return new[]
                {
                    "Id", "StreamId", "Date", "RequestId"
                };
            }
        }

        public override void Insert(System.Data.IDbConnection connection, object instance)
        {
            var request = (RequestHeader) instance;
            var sql = InsertStatement();
            var values = new
            {
                Id = request.Id,
                StreamId = request.StreamId,
                Date = request.Date,
                RequestId = request.Request.Id
            };

            connection.Execute(sql, values);

        }

        public override object Get(System.Data.IDbConnection connection, Guid id)
        {
            var sql = SelectStatementWithId();
            var match = connection.Query(sql, new {Id = id}).FirstOrDefault();
            return match == null
                ? null
                : new RequestHeader(match.Id, match.StreamId, match.Date, new RequestIdentifier(match.RequestId, null));
        }
    }
}
