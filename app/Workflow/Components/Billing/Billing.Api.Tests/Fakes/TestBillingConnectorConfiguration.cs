using Billing.Api.Connector.Configuration;

namespace Billing.Api.Tests.Fakes
{
    public class TestBillingConnectorConfiguration : IBillingConnectorConfiguration
    {
        public string Url
        {
            get { return "http://billing.lightstone.api/"; }
        }

        public string ApiKey
        {
            get { return "1234567890"; }
        }
    }
}