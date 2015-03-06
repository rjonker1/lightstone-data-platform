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
    internal class DataProviderResponseTypeMapper : TypeMapper
    {
        protected override string TableName
        {
            get { return "DataProviderResponses"; }
        }

        protected override IEnumerable<string> FieldNames
        {
            get
            {
                return new[]
                {
                    "Id", "Date", "RequestId", "DataProvider", "DataProviderName", "DataProviderRequestId"
                };
            }
        }

        public override void Insert(System.Data.IDbConnection connection, object instance)
        {
            var response = (DataProviderResponse) instance;
            var sql = InsertStatement();
            var values = new
            {
                Id = response.Response.Id,
                Date = response.Response.Date,
                RequestId = response.Response.Request.ParentRequest.Id,
                DataProvider = response.Response.Request.DataProvider.Id,
                DataProviderName = response.Response.Request.DataProvider.Name,
                DataProviderRequestId = response.Response.Request.Id
            };

            connection.Execute(sql, values);

        }

        public override object Get(System.Data.IDbConnection connection, Guid id)
        {
            var sql = SelectStatementWithId();
            var match = connection.Query(sql, new {Id = id}).FirstOrDefault();
            return match == null
                ? null
                : new DataProviderResponse(new DataProviderResponseIdentifier(match.Id, match.Date,
                    new DataProviderRequestIdentifier(match.DataProviderRequestId, match.Date,
                        new RequestIdentifier(match.RequestId, null),
                        new DataProviderIdentifier(match.DataProvider, match.DataProviderName),
                        new DataProviderConnectionTypeIdentifier())));
        }
    }
}
