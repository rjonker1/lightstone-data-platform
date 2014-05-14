using System.Linq;
using Lace.Request.Entry;
using Nancy;
using Nancy.ModelBinding;
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

                var licRequest = this.Bind<Request>();
                var request = new LicensePlateNumberRequest(licRequest.LicenseNo);
                var entryPoint = new EntryPoint();
                var responses = entryPoint.GetResponsesFromLace(request);

                return Response.AsJson(responses.First().Response);
            };
        }
    }

    public class Request
    {
        public string LicenseNo { get; set; }
    }


}