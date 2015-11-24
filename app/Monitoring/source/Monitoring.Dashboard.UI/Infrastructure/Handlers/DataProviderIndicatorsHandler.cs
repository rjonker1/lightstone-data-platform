using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Components.DictionaryAdapter;
using Common.Logging;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider;
using Monitoring.Dashboard.UI.Core.Models.DataProvider;
using Monitoring.Dashboard.UI.Core.Models.DataProvider.Events;
using Monitoring.Dashboard.UI.Domain.DataProviders;
using Monitoring.Dashboard.UI.Infrastructure.Dto.Payloads;
using Monitoring.Dashboard.UI.Infrastructure.Dto.RequestFields;
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
                var indicators =
                    _monitoring.MultipleItems<IndicatorRequestLevelDto, IndicatorRequestPerDataProviderDto, DataProviderPayloadDto, RequestPayloadDto>
                        (DataProviderIndicators.SelectStatement()).ToList();

                var requestField = new RequestField();
                ((List<RequestPayloadDto>)indicators[3]).ForEach(f =>
                {
                    requestField.DetermineRequestField(ExecutionBegan.Deserialize(f.Json));
                });

                var requestFieldCounts =
                    requestField.RequestFieldCounts.GroupBy(g => g.Name, g => g.Count, (name, count) => new
                    {
                        Name = name,
                        Total = count.Sum()

                    }).Select(s => new IndicatorRequestFieldTypeCountDto(s.Name, s.Total));


                var dataProviderRequestTimeIndicator = ((List<DataProviderPayloadDto>)indicators[2]).Select(
                    s => new ElapsedTimeDataProviderDto(ExecutionEnded.Deserialize(s.Json)))
                    .GroupBy(g => g.DataProviderName, g => g.ElapsedTimeSpan, (key, times) => new
                    {
                        DataProvider = key,
                        Times = times.ToList()
                    })
                    .Select(sg => new IndicatorRequestTimeDataProviderDto(sg.Times.Average(i => i.TotalSeconds), sg.DataProvider))
                    .ToList();


                Indicators = new DataProviderIndicatorsDto(indicators[0].FirstOrDefault(), indicators[1].ToList(), dataProviderRequestTimeIndicator, requestFieldCounts.ToList());

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred in the Monitoring Data Provider Statistics Handler because of {0}", ex,ex.Message);
                Indicators = new DataProviderIndicatorsDto(new IndicatorRequestLevelDto("00:00:00", 0, 0, 0), new List<IndicatorRequestPerDataProviderDto>(), new EditableList<IndicatorRequestTimeDataProviderDto>(), new List<IndicatorRequestFieldTypeCountDto>());
            }
        }

        public DataProviderIndicatorsDto Indicators { get; private set; }
    }
}