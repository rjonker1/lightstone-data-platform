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

        //public void Consume(IMessage<RequestReportMessage> message)
        //{
        //    var url = message.Body.Request.Url;
        //    var headers = message.Body.Request.Headers;

        //    var request = new ApiRequest(new ApiRequestIdentifier(
        //        new UrlIdentifier(url.BasePath, url.HostName, url.IsSecure, url.Path, url.Port, url.Query, url.Scheme, url.SiteBase),
        //        new HeaderIdentifier(headers.AsJsonString(), headers.Authorization, headers.Host, headers.UserAgent, headers.ContentType),
        //        message.Body.Request.Method, message.Body.Request.UserHostAddress, message.Body.RequestId));

        //    _monitoring.Add(request);
        //}
    }
}
