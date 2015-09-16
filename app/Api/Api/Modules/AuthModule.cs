using System;
using System.Collections.Generic;
using System.Configuration;
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
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["maintenanceMode"])) return Response.AsJson(new { data = "Service unavailable - Maintenance in progress" }, HttpStatusCode.ServiceUnavailable);

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