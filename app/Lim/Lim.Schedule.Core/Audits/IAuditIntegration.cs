﻿using System;
using Common.Logging;
using Lim.Domain.Entities;
using Lim.Domain.Entities.Repository;
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
        private readonly IAmRepository _repository;

        public StoreIntegrationAudit(IAmRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void Audit(AuditIntegrationCommand command)
        {
            _log.Info("Storing Integration Audit information for an API Integration to the database");
            try
            {
                var audit = new AuditApiIntegration()
                {
                    ClientId = command.ClientId,
                    ConfigurationId = command.ConfigurationId,
                    ActionType = command.Action,
                    IntegrationType = command.Type,
                    Date = DateTime.UtcNow,
                    WasSuccessful = command.WasSuccessful,
                    Address = command.Address,
                    Suffix = command.Suffix,
                    Payload = command.Payload

                };
                _repository.Save(audit);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to audit the integration information, because {0}", ex, ex.Message);
            }
        }
    }
}