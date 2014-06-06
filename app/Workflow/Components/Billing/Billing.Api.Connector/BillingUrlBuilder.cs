using Billing.Api.Connector.Configuration;

namespace Billing.Api.Connector
{
    internal class BillingUrlBuilder
    {
        private readonly IBillingConnectorConfiguration configuration;

        public BillingUrlBuilder(IBillingConnectorConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string PingSegment()
        {
            return "ping";
        }
    }
}