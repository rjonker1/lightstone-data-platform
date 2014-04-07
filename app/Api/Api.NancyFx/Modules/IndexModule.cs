using Nancy;
using Nancy.Security;

namespace Api.NancyFx.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                this.RequiresAuthentication();
                return Response.AsJson("");
            };
        }
    }
}