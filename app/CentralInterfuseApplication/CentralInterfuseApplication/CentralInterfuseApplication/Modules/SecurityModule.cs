using Nancy;
using Shared.BuildingBlocks.Api.ApiClients;

namespace CentralInterfuseApplication.Modules
{
    public class SecurityModule : NancyModule
    {
        public SecurityModule(IUserManagementApiClient client)
        {
            Get["/login"] = parameters =>
            {
                // Called when the user visits the login page or is redirected here because
                // an attempt was made to access a restricted resource. It should return
                // the view that contains the login form
                return View["Index"];
            };

            Get["/logout"] = parameters =>
            {
                // Called when the user clicks the sign out button in the application. Should
                // perform one of the Logout actions (see below)
                return null;
            };

            Post["/login"] = parameters =>
            {
                //client.Post<ApiUser>("", "/login", )


                return null;
            };
        }
    }
}