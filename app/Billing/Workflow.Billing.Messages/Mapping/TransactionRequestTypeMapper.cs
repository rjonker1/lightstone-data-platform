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
                    "Id", "RequestId", "UserId", "State", "RequestExpiration"
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
                RequestExpiration = transaction.ExpirationDate,
                State = transaction.ResponseState.Name
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
                match.Date, match.RequestExpiration);
        }
    }
}