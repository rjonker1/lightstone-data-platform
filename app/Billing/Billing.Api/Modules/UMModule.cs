using Nancy;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Billing.Api.Modules
{
    public class UMModule : NancyModule
    {
        public UMModule(IUserManagementApiClient userManagementApiClient)
        {
            Get["/Users"] = parameters => userManagementApiClient.Get("", "Users/All");
        }
    }
}