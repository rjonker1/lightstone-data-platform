namespace Shared.BuildingBlocks.Api.ApiClients
{
    public interface IPackageBuilderApiClient : IApiClient
    {
    }

    public class PackageBuilderApiClient : ApiClientBase, IPackageBuilderApiClient
    {
        public PackageBuilderApiClient() : base(AppSettings.PackageBuilderApi.BaseUrl)
        {
        }
    }
}