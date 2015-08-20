using System.Collections.Generic;
using DataPlatform.Shared.Dtos.RequestInfo;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;

namespace PackageBuilder.Api.Modules
{
    public class RequestInfoModule : SecureModule
    {
        public RequestInfoModule(IUserManagementApiClient userManagementApi)
        {
            Get["/RequestInfo"] = _ =>
            {
                var token = Context.Request.Headers.Authorization.Split(' ')[1];
                var user = userManagementApi.Get<RequestInfoDto>(token, "/RequestInfo/{username}", new[] { new KeyValuePair<string, string>("username", Context.CurrentUser.UserName) });
                return user;
            };
        }
    }
}