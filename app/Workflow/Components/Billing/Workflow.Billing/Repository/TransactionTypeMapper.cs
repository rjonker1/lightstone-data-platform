﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataPlatform.Shared.Public.Identifiers;
using Workflow.Billing.Domain;

namespace Workflow.Billing.Repository
{
    internal class TransactionTypeMapper : TypeMapper
    {
        protected override string TableName
        {
            get { return "Transaction"; }
        }

        protected override IEnumerable<string> FieldNames
        {
            get
            {
                return new[]
                {
                    "Id", "Date", "PackageId", "PackageVersion", "UserId", "RequestId", "System", "Server"
                };
            }
        }

        public override void Insert(IDbConnection connection, object instance)
        {
            var transaction = instance as Transaction;

            var sql = GenerateInsertStatement();

            var values = new
            {
                Id = transaction.Id,
                Date = transaction.Date,
                PackageId = transaction.Package.Id,
                PackageVersion = transaction.Package.Version.Number,
                UserId = transaction.User.Id,
                RequestId = transaction.Request.Id,
                System = transaction.Request.System.Name,
                Server = transaction.Request.System.Server.MachineName
            };

            connection.Execute(sql, values);
        }

        public override object Get(IDbConnection connection, Guid id)
        {
            var sql = GenerateSelectByIPrimaryKeyStatement();

            var match = connection.Query(sql, new {Id = id}).FirstOrDefault();

            if (match == null)
                return null;

            return new InvoiceTransaction(match.Id, match.Date, new PackageIdentifier(match.PackageId, new VersionIdentifier(match.PackageVersion)),
                new RequestIdentifier(match.RequestId, new SystemIdentifier(match.System)), new UserIdentifier(match.UserId));
        }
    }
}