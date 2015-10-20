using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataPlatform.Shared.Identifiers;
using Shared.BuildingBlocks.AdoNet.Mapping;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Workflow.Billing.Messages.Mapping
{
    public class TransactionRequestTypeMapper : TypeMapper
    {
        protected override string TableName
        {
            get { return "TransactionRequest"; }
        }

        protected override IEnumerable<string> FieldNames
        {
            get
            {
                return new[]
                {
                    "Id", "RequestId", "UserId", "StateId", "State", "ExpirationDate", "Created"
                };
            }
        }

        public override void Insert(IDbConnection connection, object instance)
        {
            var transaction = instance as TransactionRequest;

            var sql = GenerateInsertStatement();

            var values = new
            {
                Id = transaction.Id,
                RequestId = transaction.Request.Id,
                UserId = transaction.User.Id,
                ExpirationDate = transaction.ExpirationDate,
                State = transaction.State.Name,
                StateId = transaction.State.Id,
                Created = DateTime.UtcNow
            };

            connection.Execute(sql, values);
        }

        public override object Get(IDbConnection connection, Guid id)
        {
            var sql = GenerateSelectByIPrimaryKeyStatement();

            var match = connection.Query(sql, new {Id = id}).FirstOrDefault();

            if (match == null)
                return null;

            return new TransactionRequest(match.Id, new RequestIdentifier(match.RequestId, new SystemIdentifier(match.System)),
                new UserIdentifier(match.UserId), new StateIdentifier(match.StateId, match.State),
                match.Date);
        }
    }
}