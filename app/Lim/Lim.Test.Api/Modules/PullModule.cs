using Nancy;

namespace Lim.Test.Api.Modules
{
    public class PullModule : NancyModule
    {
        public PullModule()
        {
            Get["/api/pull"] = _ =>  Response.AsJson(new {Hello = "welcome to the pulling stuff..."});
        }
    }
}