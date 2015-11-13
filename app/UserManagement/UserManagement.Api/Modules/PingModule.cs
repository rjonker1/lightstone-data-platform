using Nancy;

namespace UserManagement.Api.Modules
{
    public class PingModule : NancyModule
    {
        public PingModule()
        {
            Get["/Ping"] = _ => Response.AsJson(new { data = "Pong" });
        }
    }
}