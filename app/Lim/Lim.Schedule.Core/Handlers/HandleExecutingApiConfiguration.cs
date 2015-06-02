using System;
using System.Linq;
using Common.Logging;
using Lim.Domain.Entities.Repository;
using Lim.Enums;
using Lim.Schedule.Core.Audits;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Tracking;

namespace Lim.Schedule.Core.Handlers
{
    public class HandleExecutingApiConfiguration : IHandleExecutingApiConfiguration
    {
        private readonly ILog _log;
        private readonly IAmRepository _repository;
        private readonly IAuditIntegration _auditLog;
        private readonly ITrackIntegration _tracking;

        public HandleExecutingApiConfiguration(IAmRepository repository, IAuditIntegration auditLog, ITrackIntegration tracking)
        {
            _repository = repository;
            _auditLog = auditLog;
            _tracking = tracking;
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
                var audit = new AuditIntegrationCommand(f.Client.ClientId, f.ConfigurationId, DateTime.UtcNow, (short) IntegrationAction.Push,
                    (short) IntegrationType.Api,
                    f.Configuration.BaseAddress, f.Configuration.Suffix);
                try
                {

                    _log.InfoFormat("Executing Push Configuration with Key {0}", f.Key);
                    f.Get(_repository, _log);
                    f.Push(audit,_log);
                    audit.Successful();

                    _tracking.Track(new TrackIntegrationCommand(audit.Payloads.Max(m => m.TransactionDate), (short) IntegrationAction.Push,
                        (short) IntegrationType.Api, f.Configuration.Frequency.Id, audit.Payloads.Count(w => w.WasSuccessful)));
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