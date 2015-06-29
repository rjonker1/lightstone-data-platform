using System.Linq;
using Lim.Domain.Entities;
using Lim.Domain.Entities.Repository;
using NHibernate;

namespace Lim.Acceptance.Tests.Integrations
{
    public class ApiIntegrationTestSetup
    {
        private readonly ISession _session;
        private readonly IAmRepository _repository;
        public ApiIntegrationTestSetup(ISession session, IAmRepository repository)
        {
            _session = session;
            _repository = repository;
        }

        public void DeleteAllAudits()
        {
            _session.CreateQuery("delete from AuditApiIntegration");
        }

        public AuditApiIntegration GetAuditLog(long configurationId)
        {
            var auditrecord = _repository.Get<AuditApiIntegration>(w => w.ConfigurationId == configurationId);
            return auditrecord.FirstOrDefault();
        }
    }
}
