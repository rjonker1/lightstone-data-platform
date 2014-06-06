using Billing.Api.Dtos;

namespace Billing.Api.Connector
{
    public interface IConnectToBilling
    {
        BillingConnectorResponse Ping(PingRequest request);
    }
}