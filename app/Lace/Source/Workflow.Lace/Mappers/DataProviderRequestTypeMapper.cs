using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Identifiers;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Repository;

namespace Workflow.Lace.Mappers
{
    internal class DataProviderRequestTypeMapper : TypeMapper
    {
        protected override string TableName
        {
            get { return "DataProviderRequests"; }
        }

        protected override IEnumerable<string> FieldNames
        {
            get
            {
                return new[]
                {
                    "Id", "StreamId", "Date", "RequestId", "DataProvider", "DataProviderName", "ConnectionType", "Connection"
                };
            }
        }

        public override void Insert(System.Data.IDbConnection connection, object instance)
        {
            var request = (DataProviderRequest) instance;
            var sql = InsertStatement();
            var values = new
            {
                Id = request.Request.Id,
                StreamId = request.Request.StreamId,
                Date = request.Request.Date,
                RequestId = request.Request.ParentRequest.Id,
                DataProvider = request.Request.DataProvider.Id,
                DataProviderName = request.Request.DataProvider.Name,
                ConnectionType = request.Request.ConnectionType.Type,
                Connection = request.Request.ConnectionType.Connection
            };

            connection.Execute(sql, values);

        }

        public override object Get(System.Data.IDbConnection connection, Guid id)
        {
            var sql = SelectStatementWithId();
            var match = connection.Query(sql, new {Id = id}).FirstOrDefault();
            return match == null
                ? null
                : new DataProviderRequest(new DataProviderRequestIdentifier(match.Id, match.StreamId,match.Date, 
                    new RequestIdentifier(match.RequestId, null),
                    new DataProviderIdentifier(match.DataProvider, match.DataProviderName),
                    new DataProviderConnectionTypeIdentifier(match.ConnectionType, match.Connection)));
        }
    }
}
