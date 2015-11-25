using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataProvider.Domain.Models;
using DataProvider.Infrastructure.Base.Handlers;
using DataProvider.Infrastructure.Commands;
using DataProvider.Infrastructure.Dto.DataProvider;
using DataProvider.Infrastructure.Repository;
using Monitoring.Domain.Repository;

namespace DataProvider.Infrastructure.Handlers
{
    public class DataProviderHandler : IHandleMonitoringCommands
    {
        private readonly IMonitoringRepository _monitoring;
        private readonly ITransactionRepository _billing;
        private static readonly ILog Log = LogManager.GetLogger<DataProviderHandler>();
        public DataProviderHandler(IMonitoringRepository monitoring,ITransactionRepository billing)
        {
            _monitoring = monitoring;
            _billing = billing;
        }

        public void Handle(GetMonitoringCommand command)
        {
            try
            {
                var requests =
                    _monitoring.Items<DataProviderMonitoring>(DataProviderMonitoring.SelectStatement()).ToArray();

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
                            new DataProviderDto(s.RequestId, payloads
                                .Where(f => f.Id == s.RequestId)
                                .Select(c => new SerializedPayload(c.Payload, c.CommitSequence)).ToList(), s.Date, false,
                                s.ElapsedTime, s.PackageVersion, s.PackageName, s.DataProviderCount).DeserializePayload()
                                .SetState(GetErrorCount(errors.FirstOrDefault(f => f.RequestId == s.RequestId))))
                        .ToList();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occured in the Monitoirng Handler because of {0}", ex, ex.Message);
                MonitoringResponse = Enumerable.Empty<DataProviderDto>().ToList();
            }
        }

        public void Handle(GetMonitoringForArumentCommand command)
        {
            try
            {
                var payloads = _monitoring.Items<DataProviderEventLogQuery>(DataProviderEventLogQuery.SelectStatement(), new { command.Argument.Argument, command.Argument.Offset, command.Argument.Next }).ToArray();

                if (!payloads.Any())
                    return;

                var errors = _billing.Items<DataProviderError>(
                    DataProviderError.SelectStatement(), new {@RequestIds = payloads.Select(s => s.Id).ToArray()}).ToArray();

                if (!errors.Any())
                    errors = new DataProviderError[] { };

                var requests =
                    payloads.GroupBy(g => new
                    {
                       RequestId = g.Id,
                       g.Date,
                       g.ElapsedTime,
                       g.PackageVersion,
                       g.PackageName,
                       g.DataProviderCount

                    }).Select(s => new DataProviderMonitoring()
                    {
                        RequestId = s.Key.RequestId,
                        Date = s.Key.Date,
                        ElapsedTime = s.Key.ElapsedTime,
                        PackageVersion = s.Key.PackageVersion,
                        PackageName = s.Key.PackageName,
                        DataProviderCount = s.Key.DataProviderCount

                    }).ToList();

                var rowCount = payloads.First().RowsCount;

                MonitoringResponse =
                    requests.Select(
                        s =>
                            new DataProviderDto(s.RequestId, payloads
                                .Where(f => f.Id == s.RequestId)
                                .Select(c => new SerializedPayload(c.Payload, c.CommitSequence)).ToList(), s.Date, false,
                                s.ElapsedTime, s.PackageVersion, s.PackageName, s.DataProviderCount, rowCount).DeserializePayload()
                                .SetState(GetErrorCount(errors.FirstOrDefault(f => f.RequestId == s.RequestId)))).ToList();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occured in the Data Provider Handler because of {0}", ex, ex.Message);
                MonitoringResponse = Enumerable.Empty<DataProviderDto>().ToList();
            }
        }

        private static int GetErrorCount(DataProviderError error)
        {
            return error == null ? 0 : error.ErrorCount;
        }

        public List<DataProviderDto> MonitoringResponse { get; private set; }
        
       
    }
}