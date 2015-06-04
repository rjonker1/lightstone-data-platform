using Nancy;

namespace Lim.Test.Api.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => View["Index"];
            Get["/cia"] = _ => Response.AsRedirect(System.Configuration.ConfigurationManager.AppSettings["url/cia"]);
        }
    }
}