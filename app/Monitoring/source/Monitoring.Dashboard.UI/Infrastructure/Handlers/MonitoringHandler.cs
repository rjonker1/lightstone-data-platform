using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Common.Logging;
using DataPlatform.Shared.Messaging;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Infrastructure.Commands;
using Monitoring.Dashboard.UI.Infrastructure.Repository;
using Monitoring.Domain.Repository;
using Workflow.Lace.Domain.Aggregates;

namespace Monitoring.Dashboard.UI.Infrastructure.Handlers
{
    public class MonitoringHandler : IHandleMonitoringCommands
    {
        private readonly IMonitoringRepository _monitoring;
       // private readonly ICommitRepository _commit;
        private CommonDomain.Persistence.IRepository _commit;
        private readonly ILog _log;
        public IEnumerable<MonitoringDataProviderView> MonitoringResponse { get; private set; }

        public MonitoringHandler(IMonitoringRepository monitoring, CommonDomain.Persistence.IRepository commit)
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
                    _monitoring.Items<MonitoringDataProvider>(SelectStatements.GetDataProviderRequestResponses);

                //var requestIds = new StringBuilder();

                //foreach (var request in requests)
                //{
                //    requestIds.Append(string.Format("{0},", request.RequestId));
                //}

                var payloads = _commit.GetById<Request>(requests.First().RequestId);

                //var payloads = _commit.Items<Commit>(SelectStatements.GetCommitForManyRequestId,
                //    new {@RequestIds = requests.First().RequestId});
               
               

                //MonitoringResponse =
                //    requests.Select(
                //        s =>
                //            new MonitoringDataProviderView(s.RequestId, payloads
                //                .Where(f => f.StreamIdOriginal == s.RequestId.ToString())
                //                .Select(p => new SerializedPayload(p.Payload, p.CommitSequence))
                //                .ToList(), s.Date, false,
                //                s.ElapsedTime, s.SearchType, s.SearchTerm).GetResults().DeserializePayload());
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred in the Monitoirng Handler because of {0}", ex.Message);
            }
        }
    }
}