using Nancy;

namespace Lim.Web.UI.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => View["Index"];
        }
    }
}