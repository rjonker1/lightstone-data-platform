using System.Data;
using System.Linq;
using Lim.Domain.Dto;
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

        public AuditIntegrationDto GetAuditLog(long configurationId)
        {
            _connection.Open();
            var auditrecord = _connection.Query<AuditIntegrationDto>("select * from AuditApiIntegration where ConfigurationId = @ConfigurationId",
                new { @ConfigurationId = configurationId });
            _connection.Close();
            return auditrecord.FirstOrDefault();
        }
    }
}
