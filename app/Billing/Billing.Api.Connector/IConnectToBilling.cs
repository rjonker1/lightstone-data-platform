using Billing.Api.Dtos;

namespace Billing.Api.Connector
{
    public interface IConnectToBilling
    {
        BillingConnectorResponse Ping(PingRequest request);
        BillingConnectorResponse CreateTransaction(CreateTransaction transaction);
        BillingConnectorResponse CreateResponse(CreateResponse transactionResponse);
        GetTransactionResponse GetTransaction(GetTransactionRequest request);
        GetResponseFromTransaction GetResponse(GetResponseRequest request);
    }
}