using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Components.DictionaryAdapter;
using Common.Logging;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider;
using Monitoring.Dashboard.UI.Core.Models.DataProvider;
using Monitoring.Dashboard.UI.Core.Models.DataProvider.Events;
using Monitoring.Dashboard.UI.Domain.Payloads;
using Monitoring.Domain.Repository;

namespace Monitoring.Dashboard.UI.Infrastructure.Handlers
{
    public class DataProviderIndicatorsHandler : IHandleDataProviderIndicators
    {
        private readonly IMonitoringRepository _monitoring;
        private static readonly ILog Log = LogManager.GetLogger<DataProviderIndicatorsHandler>();

        public DataProviderIndicatorsHandler(IMonitoringRepository monitoring)
        {
            _monitoring = monitoring;
        }

        public void Handle()
        {
            try
            {
                var indicators = _monitoring.MultipleItems(DataProviderIndicators.SelectStatement());

                if (indicators == null)
                    return;

                var requestLevel = indicators.Read<IndicatorRequestLevelDto>().ToList();
                var requestPerDataProvider = indicators.Read<IndicatorRequestPerDataProviderDto>().ToList();
                var dataProviderPayloads = indicators.Read<DataProviderPayload>().ToList();
                var requestPayloads = indicators.Read<RequestPayload>().ToList();

                var requestTypeIndicator = requestPayloads.Select(s => new RequestTypeDto(ExecutionBegan.Deserialize(s.Json))).ToList();

                var dataProviderRequestTimeIndicator = dataProviderPayloads.Select(
                    s => new ElapsedTimeDataProviderDto(ExecutionEnded.Deserialize(s.Json)))
                    .GroupBy(g => g.DataProviderName, g => g.ElapsedTimeSpan, (key, times) => new
                    {
                        DataProvider = key,
                        Times = times.ToList()
                    })
                    .Select(sg => new IndicatorRequestTimeDataProviderDto(sg.Times.Average(i => i.TotalSeconds),sg.DataProvider))
                    .ToList();


                Indicators = new DataProviderIndicatorsDto(requestLevel.FirstOrDefault(), requestPerDataProvider.ToList(), dataProviderRequestTimeIndicator);

                //Indicators =
                //    statistics.Select(
                //        s =>
                //            new DataProviderIndicatorsDto(s.AvgerageResponseTime, s.TotalRequests, s.TotalResponses,
                //                s.TotalErrors)
                //                .DetermineSuccessRate()).ToList();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred in the Monitoring Data Provider Statistics Handler because of {0}", ex,ex.Message);
                Indicators = new DataProviderIndicatorsDto(new IndicatorRequestLevelDto("00:00:00", 0, 0, 0), new List<IndicatorRequestPerDataProviderDto>(), new EditableList<IndicatorRequestTimeDataProviderDto>());
            }
        }

        public DataProviderIndicatorsDto Indicators { get; private set; }
    }
}