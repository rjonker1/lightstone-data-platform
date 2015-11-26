using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataProvider.Domain.Models;
using DataProvider.Infrastructure.Base.Handlers;
using DataProvider.Infrastructure.Commands;
using DataProvider.Infrastructure.Dto.DataProvider;
using Monitoring.Domain.Repository;

namespace DataProvider.Infrastructure.Handlers
{
    public class DataProviderErrorHandler : IHandleDataProviderErrors
    {
        private readonly IMonitoringRepository _monitoring;

        private static readonly ILog Log = LogManager.GetLogger<DataProviderErrorHandler>();

        public DataProviderErrorHandler(IMonitoringRepository monitoring)
        {
            _monitoring = monitoring;
        }

        public void Handle(GetMonitoringCommand command)
        {
            try
            {
                var requests =
                    _monitoring.MultipleItems<DataProviderMonitoring, DataProviderEventLog>(DataProviderMonitoring.SelectErrorsStatement()).ToArray();

                if (!requests.Any())
                    return;

                var payloads = (List<DataProviderEventLog>) requests[1]; //_monitoring.Items<DataProviderEventLog>(DataProviderEventLog.SelectErrorsStatement()).ToArray();
                var responses = (List<DataProviderMonitoring>) requests[0];

                if (!payloads.Any())
                    return;

                ErrorResponse =
                    responses.Select(
                        s =>
                            new DataProviderDto(s.RequestId, payloads
                                .Where(f => f.Id == s.RequestId)
                                .Select(c => new SerializedPayload(c.Payload, c.CommitSequence)).ToList(), s.Date, true,
                                s.ElapsedTime, s.PackageVersion, s.PackageName, s.DataProviderCount).DeserializePayload()
                                .SetState(1)).ToList();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occured in the Data Provider Error Handler because of {0}", ex, ex.Message);
                ErrorResponse = Enumerable.Empty<DataProviderDto>().ToList();
            }
        }

        public List<DataProviderDto> ErrorResponse { get; private set; }
    }
}