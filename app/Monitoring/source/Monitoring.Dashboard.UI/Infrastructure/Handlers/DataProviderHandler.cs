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
    public class DataProviderHandler : IHandleMonitoringCommands
    {
        private readonly IMonitoringRepository _monitoring;
        private readonly ICommitRepository _commit;
        private readonly ITransactionRepository _billing;
        private readonly ILog _log;
        public IEnumerable<DataProviderView> MonitoringResponse { get; private set; }

        public DataProviderHandler(IMonitoringRepository monitoring, ICommitRepository commit,
            ITransactionRepository billing)
        {
            _monitoring = monitoring;
            _commit = commit;
            _billing = billing;
            _log = LogManager.GetLogger(GetType());
        }

        public void Handle(GetMonitoringCommand command)
        {
            try
            {
                var requests =
                    _monitoring.Items<DataProvider>(SelectStatements.GetDataProviderRequestResponses).ToArray();

                if (!requests.Any())
                    return;

                var payloads = _commit.Items<Commit>(SelectStatements.GetCommitForManyRequestId,
                    new {@RequestIds = requests.Select(s => s.RequestId).ToArray()})
                    .OrderBy(o => o.StreamIdOriginal)
                    .ThenBy(o => o.CommitSequence)
                    .ToArray();

                var errors = _billing.Items<DataProviderError>(
                    SelectStatements.GetNumberOfErrorsPerRequest,
                    new {@RequestIds = requests.Select(s => s.RequestId).ToArray()}).ToArray();

                if (!errors.Any())
                    errors = new DataProviderError[] {};


                MonitoringResponse =
                    requests.Select(
                        s =>
                            new DataProviderView(s.RequestId, payloads
                                .Where(f => f.StreamIdOriginal == s.RequestId.ToString())
                                .Select(c => new SerializedPayload(c.Payload, c.CommitSequence)).ToList(), s.Date, false,
                                s.ElapsedTime, s.SearchType, s.SearchTerm).DeserializePayload()
                                .SetState(GetErrorCount(errors.FirstOrDefault(f => f.RequestId == s.RequestId)))).ToList();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred in the Monitoirng Handler because of {0}", ex.Message);
            }
        }

        private static int GetErrorCount(DataProviderError error)
        {
            return error == null ? 0 : error.ErrorCount;
        }

    }
}