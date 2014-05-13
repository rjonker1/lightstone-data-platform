using System.Linq;
using Lace.Request.Entry;
using Nancy;
using Nancy.Security;

namespace Api.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Post["/license"] = parameters =>
            {
                this.RequiresAuthentication();

                return HttpStatusCode.OK;
            };

            Post["/license/{licenseNo}"] = parameters =>
            {
                this.RequiresAuthentication();

                var request = new LicensePlateNumberRequest(parameters.licenseNo, new[] { "Ivid", "IvidTitleHolder", "RgtVin", "Audatex" });
                var entryPoint = new EntryPoint();
                var responses = entryPoint.GetResponsesFromLace(request);

                return Response.AsJson(responses.First().Response);
            };
        }
    }
}