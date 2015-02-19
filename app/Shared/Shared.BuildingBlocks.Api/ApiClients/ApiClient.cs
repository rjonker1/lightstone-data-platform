namespace Shared.BuildingBlocks.Api.ApiClients
{
    public class ApiClient : ApiClientBase
    {
        public ApiClient() : base(AppSettings.Api.BaseUrl)
        {
        }
    }
}