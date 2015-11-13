namespace Shared.BuildingBlocks.Api.ApiClients
{
    public interface IBillingApiClient : IApiClient { }

    public class BillingApiClient : ApiClientBase, IBillingApiClient
    {
        public BillingApiClient() : base(AppSettings.BillingApi.BaseUrl)
        {
        }
    }
}