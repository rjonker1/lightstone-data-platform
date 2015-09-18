using System;
using System.Linq;
using Common.Logging;
using Lim.Schedule.Core.Audits;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Tracking;
using IntegrationType = Lim.Enums.IntegrationType;

namespace Lim.Schedule.Core.Handlers
{
    public class HandleExecutingApiConfiguration : IHandleExecutingApiConfiguration
    {
        private static readonly ILog Log = LogManager.GetLogger<HandleExecutingApiConfiguration>();
        private readonly IAuditIntegration _auditLog;
        private readonly ITrackIntegration _tracking;

        public HandleExecutingApiConfiguration(IAuditIntegration auditLog, ITrackIntegration tracking)
        {
            _auditLog = auditLog;
            _tracking = tracking;
        }

        public void Handle(ExecuteApiPushConfigurationCommand command)
        {
            if (command.Configurations == null || !command.Configurations.Any())
            {
                Log.Info("There are not configurations to execute");
                return;
            }

            Log.InfoFormat("Executing {0} API Push Configurations", command.Configurations.Count());
            command.Configurations.ToList().ForEach(f =>
            {
                try
                {
                    Log.InfoFormat("Executing Push Configuration with Key {0}", f.Key);
                    f.Pusher.Push(f.Command);
                    f.Audit.Successful();

                    if (f.Audit.Payloads != null && f.Audit.Payloads.Any())
                        _tracking.Track(new TrackIntegrationCommand(f.Audit.Payloads.Max(m => m.TransactionDate), f.ConfigurationId,
                            f.Audit.Payloads.Count(w => w.WasSuccessful)));
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("An error occurred executing API Push configuration because of {0}", ex, ex.Message);
                    f.Audit.Failed();
                }
                _auditLog.Audit(f.Audit);
            });

            IsHandled = true;
        }

        public void Handle(ExecuteApiPullConfigurationCommand command)
        {
            throw new NotImplementedException();
        }

        public bool IsHandled { get; private set; }
    }
}