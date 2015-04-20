using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Infrastructure.Commands;
using Monitoring.Dashboard.UI.Infrastructure.Repository;
using Monitoring.Domain.Repository;

namespace Monitoring.Dashboard.UI.Infrastructure.Handlers
{
    public class MonitoringHandler : IHandleMonitoringCommands
    {
        private readonly IMonitoringRepository _monitoring;
        private readonly ICommitRepository _commit;
        private readonly ILog _log;
        public IEnumerable<MonitoringDataProviderView> MonitoringResponse { get; private set; }

        public MonitoringHandler(IMonitoringRepository monitoring, ICommitRepository commit)
        {
            _monitoring = monitoring;
            _commit = commit;
            _log = LogManager.GetLogger(GetType());
        }

        public void Handle(GetMonitoringCommand command)
        {
            try
            {
                var requests =
                    _monitoring.Items<MonitoringDataProvider>(SelectStatements.GetDataProviderRequestResponses).ToList();

                if (!requests.Any())
                    return;

                var payloads = new List<Commit>();

                requests.ForEach(
                    f =>
                        payloads.AddRange(_commit.Items<Commit>(SelectStatements.GetCommitForRequestId,
                            new {@RequestId = f.RequestId}).ToArray()));

                //var payloads = _commit.Items<Commit>(SelectStatements.GetCommitForRequestId,
                //    new {@RequestIds = requests.FirstOrDefault().RequestId});

                MonitoringResponse =
                    requests.Select(
                        s =>
                            new MonitoringDataProviderView(s.RequestId, payloads
                                .Where(f => f.StreamIdOriginal == s.RequestId.ToString())
                                .Select(c => new SerializedPayload(c.Payload, c.CommitSequence)).ToList(), s.Date, false,
                                s.ElapsedTime, s.SearchType, s.SearchTerm).GetResults().DeserializePayload());
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred in the Monitoirng Handler because of {0}", ex.Message);
            }
        }
    }
}