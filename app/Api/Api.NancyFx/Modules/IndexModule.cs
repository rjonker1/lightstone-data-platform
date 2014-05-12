using System.Linq;
using Lace;
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

            Post["/license/{licenseNo}"] = parameters =>
            {
                this.RequiresAuthentication();

                var request = new LicensePlateNumberRequest(parameters.licenseNo, new[] { "Ivid", "IvidTitleHolder", "RgtVin", "Audatex" });
                var init = new Initialize(request);

                return Response.AsJson(init.LaceResponses.First().Response);
            };
        }
    }
}