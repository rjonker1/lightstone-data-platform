using Monitoring.Domain.Identifiers;

namespace Monitoring.Domain
{
    public class MonitoringApiRequest
    {
        public MonitoringApiRequest(ApiRequestIdentifier request)
        {
            Request = request;
        }
        public ApiRequestIdentifier Request { get; private set; }
    }
}
