using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Identifiers;
using Workflow.Billing.Repository;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Mappers
{
    internal class DataProviderTransactionTypeMapper : TypeMapper
    {
        protected override string TableName
        {
            get { return "DataProviderTransaction"; }
        }

        protected override IEnumerable<string> FieldNames
        {
            get
            {
                return new[]
                {
                    "Id", "StreamId", "Date", "RequestId", "DataProvider", "DataProviderName", "ConnectionType",
                    "Connection", "Action", "State"
                };
            }
        }

        public override void Insert(System.Data.IDbConnection connection, object instance)
        {
            var request = (DataProviderTransaction) instance;
            var sql = GenerateInsertStatement();
            var values = new
            {
                Id = request.Transaction.Id,
                StreamId = request.Transaction.StreamId,
                Date = request.Transaction.Date,
                RequestId = request.Transaction.ParentRequest.Id,
                DataProvider = request.Transaction.DataProvider.Id,
                DataProviderName = request.Transaction.DataProvider.Name,
                ConnectionType = request.Transaction.ConnectionType.Type,
                Connection = request.Transaction.ConnectionType.Connection,
                Action = request.Transaction.Action.Name,
                State = request.Transaction.State.Name
            };

            connection.Execute(sql, values);

        }

        public override object Get(System.Data.IDbConnection connection, Guid id)
        {
            var sql = GenerateSelectByIPrimaryKeyStatement();
            var match = connection.Query(sql, new {Id = id}).FirstOrDefault();
            return match == null
                ? null
                : new DataProviderTransaction(new DataProviderTransactionIdentifier(match.Id, match.StreamId, match.Date,
                    new RequestIdentifier(match.RequestId, null),
                    new DataProviderIdentifier(match.DataProvider, match.DataProviderName),
                    new ConnectionTypeIdentifier(match.ConnectionType, match.Connection),
                    new ActionIdentifier(0, match.Name), new StateIdentifier(0, match.State)));
        }
    }
}
