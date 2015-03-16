using Nancy;
using Nancy.Security;

namespace CentralInterfuseApplication.Api.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters =>
            {
                //this.RequiresAuthentication();
                return View["Index"];
            };
        }
    }
}