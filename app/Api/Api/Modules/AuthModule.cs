using System.Collections.Generic;
using System.Linq;
using Nancy;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Api.Modules
{
    public class AuthModule : NancyModule
    {
        public AuthModule(IUserManagementApiClient userManagementApi)
        {
            Post["/login"] = parameters =>
            {
                var username = Context.Request.Headers["Username"].FirstOrDefault();
                var password = Context.Request.Headers["Password"].FirstOrDefault();

                var response = userManagementApi.Post("", "/login/api", null, null, new[]
                {
                    new KeyValuePair<string, string>("Username", username), 
                    new KeyValuePair<string, string>("Password", password)
                });

                return response;
            };
        }
    }
}