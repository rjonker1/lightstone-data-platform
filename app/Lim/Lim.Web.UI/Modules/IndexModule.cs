using Nancy;

namespace Lim.Web.UI.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => View["Index"];

            Get["/cia"] = parameters => Response.AsRedirect(System.Configuration.ConfigurationManager.AppSettings["url/cia"]);
        }
    }
}