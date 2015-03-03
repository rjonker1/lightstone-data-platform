using System.Runtime.Remoting.Messaging;
using Billing.Api.Connector.Configuration;

namespace Billing.Api.Connector
{
    internal class BillingUrlBuilder
    {
        private readonly IBillingConnectorConfiguration _configuration;

        public BillingUrlBuilder(IBillingConnectorConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string PingSegment()
        {
            return "ping";
        }

        public string CreateTransactionSegment()
        {
            return "/transaction";
        }

        public string GetTransactionSegment()
        {
            return "/transaction";
        }
    }
}