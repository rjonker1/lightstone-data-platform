using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Domain.UserAgent;
using Monitoring.Dashboard.UI.Infrastructure.Dto;
using Monitoring.Dashboard.UI.Infrastructure.Factory;
using Monitoring.Domain.Repository;

namespace Monitoring.Dashboard.UI.Infrastructure.Handlers
{
    public class ApiRequestHandler : IHandleApiRequests
    {
        private readonly IMonitoringRepository _monitoring;
        private readonly IDetermineUserAgent _determinator;
        private static readonly ILog Log = LogManager.GetLogger<ApiRequestHandler>();

        public ApiRequestHandler(IMonitoringRepository monitoring, IDetermineUserAgentFactory userAgentFactory)
        {
            _monitoring = monitoring;
            _determinator = userAgentFactory.Create();
        }

        public void Handle()
        {
            try
            {
                var requests =
                    _monitoring.Items<ApiRequestMonitoring>(ApiRequestMonitoring.SelectStatement()).ToList();

                if (!requests.Any())
                    return;

                var monitoringRequests =
                    requests.Select(
                        s =>
                            new ApiRequestMonitoringDto(s.RequestId, s.RequestDate, s.UserHostAddress, s.Authorization, s.UserName, s.Method,
                                s.BasePath, s.HostName, s.IsSecure, s.Port, s.Query, s.SiteBase, s.Scheme, s.Host, s.UserAgent, s.ContentType,
                                s.CommitDate)).ToList();

             
                var userAgents = new List<ApiRequestUserAgentDto>();
                _determinator.DetermineUserAgent(monitoringRequests.Select(s => s.UserAgent).ToList(), userAgents);

                ApiRequests = new ApiRequestDto(userAgents, monitoringRequests);

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred in the Monitoirng Data Provider Statistics Handler because of {0}", ex,
                    ex.Message);
                ApiRequests = new ApiRequestDto(new List<ApiRequestUserAgentDto>(), new List<ApiRequestMonitoringDto>());
            }
        }

        public ApiRequestDto ApiRequests { get; private set; }
    }
}