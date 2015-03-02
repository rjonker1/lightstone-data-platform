using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataPlatform.Shared.Identifiers;
using Workflow.Billing.Domain;

namespace Workflow.Billing.Repository
{
    internal class ResponseTypeMapper : TypeMapper
    {
        protected override string TableName
        {
            get { return "Response"; }
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
            var request = instance as Response;

            var sql = GenerateInsertStatement();

            var values = new
            {
                Id = request.Id,
                Date = request.Date,
                PackageId = request.Package.Id,
                PackageVersion = request.Package.Version.Number,
                UserId = request.User.Id,
                RequestId = request.Request.Id,
                System = request.Request.System.Name,
                Server = request.Request.System.Server.MachineName
            };

            connection.Execute(sql, values);
        }

        public override object Get(IDbConnection connection, Guid id)
        {
            var sql = GenerateSelectByIPrimaryKeyStatement();

            var match = connection.Query(sql, new {Id = id}).FirstOrDefault();

            if (match == null)
                return null;

            return new InvoiceResponse(match.Id, match.Date, new PackageIdentifier(match.PackageId, new VersionIdentifier(match.PackageVersion)),
                new RequestIdentifier(match.RequestId, new SystemIdentifier(match.System)), new UserIdentifier(match.UserId));
        }
    }
}