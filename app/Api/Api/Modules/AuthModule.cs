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

                var response = userManagementApi.Post(null, "/login/api", null, new[]
                {
                    new KeyValuePair<string, string>("Username", username),
                    new KeyValuePair<string, string>("Password", password),
                    new KeyValuePair<string, string>("Content-Type", "application/json")
                });

                return response;
            };
        }
    }
}