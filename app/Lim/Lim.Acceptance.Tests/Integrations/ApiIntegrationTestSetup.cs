using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lim.Domain.Models;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lim.Acceptance.Tests.Integrations
{
    public class ApiIntegrationTestSetup
    {
        private readonly IDbConnection _connection;
        public ApiIntegrationTestSetup(IDbConnection connection)
        {
            _connection = connection;
        }

        public void DeleteAllAudits()
        {
             _connection.Open();
            _connection.Execute("truncate table AuditApiIntegration");
        }

        public AuditIntegration GetAuditLog(Guid configurationKey)
        {
            _connection.Open();
            var auditrecord = _connection.Query<AuditIntegration>("select * from AuditApiIntegration where ConfigurationKey = @ConfigurationKey",
                new { @ConfigurationKey = configurationKey });
            _connection.Close();
            return auditrecord.FirstOrDefault();
        }
    }
}
