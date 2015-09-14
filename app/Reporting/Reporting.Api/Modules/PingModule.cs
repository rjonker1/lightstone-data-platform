using Nancy;

namespace Reporting.Api.Modules
{
    public class PingModule : NancyModule
    {
        public PingModule()
        {
            Get["/Ping"] = _ => Response.AsJson(new { data = "Pong" });
        }
    }
}