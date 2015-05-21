using Nancy;
using Shared.BuildingBlocks.Api.Security;

namespace Billing.Api.Modules
{
    public class IndexModule : SecureModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                //"Billing API"
                return View["Index"];
            };

            Get["/logout"] = parameters => null;

            Get["/cia"] = parameters => Response.AsRedirect("http://dev.cia.lightstone.co.za/");
        }
    }
}