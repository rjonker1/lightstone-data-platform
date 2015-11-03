using System;
using Api.Domain.Core.Messages;
using DataPlatform.Shared.Helpers;
using EasyNetQ;
using Lace.Shared.Extensions;
using Monitoring.Domain;
using Monitoring.Domain.Identifiers;
using Monitoring.Domain.Repository;

namespace Workflow.Transactions.Receiver.Service.Handlers
{
    public class ApiRequestReceiver
    {
        private readonly IMonitoringRepository _monitoring;

        public ApiRequestReceiver(IMonitoringRepository monitoring)
        {
            _monitoring = monitoring;
        }

        public void Consume(IMessage<RequestMetadataMessage> message)
        {
            var url = message.Body.Url;
            var headers = message.Body.Header;

            var request = new MonitoringApiRequest(new ApiRequestIdentifier(
                new UrlIdentifier(url.BasePath, url.HostName, url.IsSecure, url.Path, url.Port, url.Query, url.Scheme, url.SiteBase),
                new HeaderIdentifier(headers.Authorization, headers.Host, headers.UserAgent, headers.ContentType),
                message.Body.Method, message.Body.UserHostAddress, message.Body.RequestId,
                message.Body.Date == DateTime.MinValue ? SystemTime.Now() : message.Body.Date,
                message.Body.ObjectToJson()));

            _monitoring.Add(request);
        }
    }
}