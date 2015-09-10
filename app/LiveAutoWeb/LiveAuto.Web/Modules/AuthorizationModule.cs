using LiveAuto.Api.Routes;
using Nancy;

namespace LiveAuto.Web.Modules
{
    public class AuthorizationModule : NancyModule
    {
        public AuthorizationModule()
        {
            Get[LiveAutoApiRoute.Authorization.ChangePassword] = parameters =>
            {
                return View["index"];
            };
        }
    }
}