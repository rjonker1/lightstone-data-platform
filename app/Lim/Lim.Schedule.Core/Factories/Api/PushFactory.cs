using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Push.RestApi;
using Lim.Schedule.Core.Audits;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Factories.FlatFile;
using Lim.Schedule.Core.Identifiers;
using Lim.Schedule.Core.Tracking;
using Newtonsoft.Json;

namespace Lim.Schedule.Core.Factories.Api
{
    public class PushFactory : AbstractPushFactory<ApiInitializePushCommand>
    {
        private static readonly ILog Log = LogManager.GetLogger<PullFactory>();
        private readonly IInitialize<ApiInitializePushCommand> _initialize;
        private readonly ITrackIntegration _tracking;
        private readonly IAuditIntegration _auditLog;

        public PushFactory(IInitialize<ApiInitializePushCommand> initialize, ITrackIntegration tracking, IAuditIntegration auditLog)
        {
            _initialize = initialize;
            _tracking = tracking;
            _auditLog = auditLog;
        }

        public override void Push(ApiInitializePushCommand command)
        {
            _initialize.Init(command);

            if(!command.PackageTransactions.Any())
                return;

            var client = _pushClients.FirstOrDefault(w => w.Key == command.AuthenticationType);
            if (client.Value == null)
                throw new Exception(string.Format("Push Client for Authentication Type {0} could not be found", command.AuthenticationType.ToString()));

            foreach (var packageTransaction in command.PackageTransactions)
            {
                try
                {
                    client.Value(command.Configuration).Post(packageTransaction);
                    command.Audit.SetPayload(JsonConvert.SerializeObject(packageTransaction), true, packageTransaction.CommitDate);
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("An error occurred executing API configuration because of {0}", ex, ex.Message);
                    command.Audit.SetPayload(JsonConvert.SerializeObject(packageTransaction), false, DateTime.MinValue);
                }
            }

            _tracking.Track(new TrackIntegrationCommand(command.Audit.Payloads.Max(m => m.TransactionDate), command.ConfigurationId,
                         command.Audit.Payloads.Count(w => w.WasSuccessful)));

            command.Audit.IsSuccessful(command.Audit.Payloads.Count(w => !w.WasSuccessful) == 0);
            _auditLog.Audit(command.Audit);

        }

        private readonly IDictionary<Enums.AuthenticationType, Func<ApiConfigurationIdentifier, PushClient>> _pushClients = new Dictionary
           <Enums.AuthenticationType, Func<ApiConfigurationIdentifier, PushClient>>()
        {
            {
                Enums.AuthenticationType.Basic, (configuration) =>
                    PushClient.PushWithBasic(configuration.BaseAddress, configuration.Suffix, configuration.Authentication.AuthenticationKey,
                        configuration.Authentication.AuthenticationToken, configuration.Authentication.Username, configuration.Authentication.Password)
            },
            {Enums.AuthenticationType.None, (configuration) => PushClient.Push(configuration.BaseAddress, configuration.Suffix)},
            {
                Enums.AuthenticationType.Stateless, (configuration) =>
                    PushClient.PushWithStateless(configuration.BaseAddress, configuration.Suffix, configuration.Authentication.AuthenticationKey,
                        configuration.Authentication.AuthenticationToken)
            }
        };
    }
}
