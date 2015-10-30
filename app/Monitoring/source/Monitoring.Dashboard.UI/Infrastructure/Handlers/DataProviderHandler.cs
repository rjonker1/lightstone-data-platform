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
        private readonly ITransactionRepository _billing;
        private static readonly ILog Log = LogManager.GetLogger<DataProviderHandler>();
        public IEnumerable<DataProviderView> MonitoringResponse { get; private set; }

        public DataProviderHandler(IMonitoringRepository monitoring,
            ITransactionRepository billing)
        {
            _monitoring = monitoring;
            _billing = billing;
        }

        public void Handle(GetMonitoringCommand command)
        {
            try
            {
                var requests =
                    _monitoring.Items<DataProvider>(DataProvider.SelectStatement()).ToArray();


                if (!requests.Any())
                    return;

                var payloads = _monitoring.Items<DataProviderEventLog>(DataProviderEventLog.SelectStatement()).ToArray();

                if (!payloads.Any())
                    return;

                var errors = _billing.Items<DataProviderError>(
                    DataProviderError.SelectStatement(), new {@RequestIds = requests.Select(s => s.RequestId).ToArray()}).ToArray();

                if (!errors.Any())
                    errors = new DataProviderError[] {};

                MonitoringResponse =
                    requests.Select(
                        s =>
                            new DataProviderView(s.RequestId, payloads
                                .Where(f => f.Id == s.RequestId)
                                .Select(c => new SerializedPayload(c.Payload, c.CommitSequence)).ToList(), s.Date, false,
                                s.ElapsedTime, s.PackageVersion, s.PackageName, s.DataProviderCount).DeserializePayload()
                                .SetState(GetErrorCount(errors.FirstOrDefault(f => f.RequestId == s.RequestId))))
                        .ToList();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occured in the Monitoirng Handler because of {0}", ex.Message);
            }
        }

        private static int GetErrorCount(DataProviderError error)
        {
            return error == null ? 0 : error.ErrorCount;
        }

    }
}