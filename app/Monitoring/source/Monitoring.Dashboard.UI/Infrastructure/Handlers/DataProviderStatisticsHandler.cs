using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Infrastructure.Dto;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Domain.Repository;

namespace Monitoring.Dashboard.UI.Infrastructure.Handlers
{
    public class DataProviderStatisticsHandler : IHandleDataProviderStatistics
    {
        private readonly IMonitoringRepository _monitoring;
        private static readonly ILog Log = LogManager.GetLogger<DataProviderStatisticsHandler>();

        public DataProviderStatisticsHandler(IMonitoringRepository monitoring)
        {
            _monitoring = monitoring;
        }

        public void Handle()
        {
            try
            {
                var statistics =
                    _monitoring.Items<DataProviderStatistics>(DataProviderStatistics.SelectStatement()).ToList();

                if (!statistics.Any())
                    return;

                StatisticsResponse =
                    statistics.Select(
                        s =>
                            new DataProviderStatisticsDto(s.AvgerageRequestTime, s.TotalRequests, s.TotalResponses,
                                s.TotalErrors)
                                .DetermineSuccessRate()).ToList();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred in the Monitoirng Data Provider Statistics Handler because of {0}", ex,
                    ex.Message);
                StatisticsResponse = new[] { new DataProviderStatisticsDto("00:00:00", 0, 0, 0) }.ToList();
            }
        }

        public List<DataProviderStatisticsDto> StatisticsResponse { get; private set; }


    }
}