using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Infrastructure.Repository;
using Monitoring.Domain.Repository;

namespace Monitoring.Dashboard.UI.Infrastructure.Handlers
{
    public class DataProviderStatisticsHandler : IHandleDataProviderStatistics
    {
        private readonly IMonitoringRepository _monitoring;
        private readonly ILog _log;

        public DataProviderStatisticsHandler(IMonitoringRepository monitoring)
        {
            _monitoring = monitoring;
            _log = LogManager.GetLogger(GetType());
        }

        public void Handle()
        {
            try
            {
                var statistics =
                    _monitoring.Items<DataProviderStatistics>(SelectStatements.GetDataProviderStatistics).ToList();

                if (!statistics.Any())
                    return;

                StatisticsResponse =
                    statistics.Select(
                        s =>
                            new DataProviderStatisticsView(s.AvgerageRequestTime, s.TotalRequests, s.TotalResponses,
                                s.TotalErrors)
                                .DetermineSuccessRate());
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred in the Monitoirng Data Provider Statistics Handler because of {0}",
                    ex.Message);
                StatisticsResponse = new[] {new DataProviderStatisticsView("00:00:00", 0, 0, 0)};
            }
        }

        public IEnumerable<DataProviderStatisticsView> StatisticsResponse { get; private set; }


    }
}