namespace Billing.Api.Connector
{
    public class BillingConnectorResponse
    {
        public bool Success { get; private set; }

        public BillingConnectorResponse(bool success)
        {
            Success = success;
        }

        public override string ToString()
        {
            return string.Format("Billing connector response: SUCCESS: {0}", Success);
        }
    }
}