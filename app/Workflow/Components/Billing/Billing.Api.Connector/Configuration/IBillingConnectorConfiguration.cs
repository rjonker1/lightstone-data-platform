namespace Billing.Api.Connector.Configuration
{
    public interface IBillingConnectorConfiguration
    {
        string Url { get; }
        string ApiKey { get; }
    }


}