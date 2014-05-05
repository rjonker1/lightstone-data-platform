using Nancy;
using Nancy.Security;

namespace Api.NancyFx.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Post["/"] = parameters =>
            {
                this.RequiresAuthentication();

                return Response.AsJson("Authenticated!");
            };
        }
    }
}