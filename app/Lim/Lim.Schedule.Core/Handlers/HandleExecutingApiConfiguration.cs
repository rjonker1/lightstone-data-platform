﻿using System;
using System.Linq;
using Common.Logging;
using Lim.Domain.Repository;
using Lim.Enums;
using Lim.Schedule.Core.Audits;
using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core.Handlers
{
    public class HandleExecutingApiConfiguration : IHandleExecutingApiConfiguration
    {
        private readonly ILog _log;
        private readonly ILimRepository _repository;
        private readonly IAuditIntegration _auditLog;

        public HandleExecutingApiConfiguration(ILimRepository repository, IAuditIntegration auditLog)
        {
            _repository = repository;
            _auditLog = auditLog;
            _log = LogManager.GetLogger(GetType());
        }

        public void Handle(ExecuteApiPushConfigurationCommand command)
        {
            if (command.Configurations == null || !command.Configurations.Any())
            {
                _log.Info("There are not configurations to execute");
                return;
            }

            _log.InfoFormat("Executing {0} API Push Configurations", command.Configurations.Count());
            command.Configurations.ToList().ForEach(f =>
            {
                var audit = new AuditIntegrationCommand(f.Key, DateTime.UtcNow, IntegrationAction.Push, IntegrationType.Api,
                    f.Configuration.BaseAddress, f.Configuration.Suffix);
                try
                {

                    _log.InfoFormat("Executing Push Configuration with Key {0}", f.Key);
                    f.Get(_repository);
                    f.Push(audit);
                    audit.Successful();
                }
                catch (Exception ex)
                {
                    _log.ErrorFormat("An error occurred executing API Push configuration because of {0}", ex, ex.Message);
                    audit.Failed();
                }

                _auditLog.Audit(audit);
            });
        }

        public void Handle(ExecuteApiPullConfigurationCommand command)
        {
            throw new NotImplementedException();
        }
    }
}