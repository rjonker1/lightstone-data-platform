using Nancy;
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
                return null;
            };

            Post["/login"] = parameters =>
            {
                //client.Post<ApiUser>("", "/login", )


                return Response.AsRedirect("/");
            };
        }
    }
}