using Nancy;

namespace Lim.Web.UI.Modules
{
    public class PingModule : NancyModule
    {
        public PingModule()
        {
            Get["/Ping"] = _ => Response.AsJson(new { data = "Pong" });
        }
    }
}