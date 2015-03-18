using System;
using Nancy;
using Nancy.Authentication.Forms;
using Shared.BuildingBlocks.Api.ApiClients;

namespace CentralInterfuseApplication.Api.Modules
{
    public class SecurityModule : NancyModule
    {
        public SecurityModule(IUserManagementApiClient client)
        {
            Get["/login"] = parameters =>
            {
                return View["Index"];
            };

            Get["/logout"] = parameters =>
            {
                return this.Logout("/");
            };

            Post["/login"] = parameters =>
            {
                //client.Post<ApiUser>("", "/login", )
                return this.LoginAndRedirect(Guid.NewGuid());
            };
        }
    }
}