using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Infrastructure.Dto;
using Monitoring.Domain.Repository;

namespace Monitoring.Dashboard.UI.Infrastructure.Handlers
{
    public class ApiRequestHandler : IHandleApiRequests
    {
        private readonly IMonitoringRepository _monitoring;
        private static readonly ILog Log = LogManager.GetLogger<ApiRequestHandler>();

        public ApiRequestHandler(IMonitoringRepository monitoring)
        {
            _monitoring = monitoring;
        }

        public void Handle()
        {
            try
            {
                var requests =
                    _monitoring.Items<ApiRequestMonitoring>(ApiRequestMonitoring.SelectStatement()).ToList();

                if (!requests.Any())
                    return;

                ApiRequests =
                    requests.Select(
                        s =>
                            new ApiRequestMonitoringDto(s.RequestId, s.RequestDate, s.UserHostAddress, s.Authorization, s.UserName, s.Method,
                                s.BasePath, s.HostName, s.IsSecure, s.Port, s.Query, s.SiteBase, s.Scheme, s.Host, s.UserAgent, s.ContentType,
                                s.CommitDate)).ToList();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred in the Monitoirng Data Provider Statistics Handler because of {0}", ex,
                    ex.Message);
                ApiRequests = Enumerable.Empty<ApiRequestMonitoringDto>().ToList();
            }
        }

        public List<ApiRequestMonitoringDto> ApiRequests { get; private set; }
    }
}