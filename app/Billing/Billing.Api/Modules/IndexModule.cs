using Nancy;

namespace Billing.Api.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                //"Billing API"
                return View["Index"];
            };
        }
    }
}