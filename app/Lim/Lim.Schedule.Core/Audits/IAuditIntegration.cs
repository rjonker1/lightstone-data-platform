using System;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Entities;
using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core.Audits
{
    public interface IAuditIntegration
    {
        void Audit(AuditIntegrationCommand command);
    }

    public class StoreIntegrationAudit : IAuditIntegration
    {
        private readonly ILog _log;
        private readonly IRepository _repository;

        public StoreIntegrationAudit(IRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void Audit(AuditIntegrationCommand command)
        {
            _log.Info("Storing Integration Audit information for an API Integration to the database");
            try
            {
                if (command.Payloads == null || !command.Payloads.Any())
                    return;

                foreach (var payload in command.Payloads)
                {
                    _repository.Save(new AuditApiIntegration()
                    {
                        ClientId = command.ClientId,
                        ConfigurationId = command.ConfigurationId,
                        ActionType = command.Action,
                        IntegrationType = command.Type,
                        Date = DateTime.UtcNow,
                        WasSuccessful = payload.WasSuccessful,
                        Address = command.Address,
                        Suffix = command.Suffix,
                        Payload = payload.Payload ?? string.Empty

                    });
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to audit the integration information, because {0}", ex, ex.Message);
            }
        }
    }
}