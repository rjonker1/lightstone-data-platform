using Nancy;

namespace CentralInterfuseApplication.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters =>
            {
                return View["Index"];
            };
        }
    }
}