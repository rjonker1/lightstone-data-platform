using System.Linq;
using Lace.Request.Entry;
using Nancy;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api;
using Shared.BuildingBlocks.Api.Security;
using Workflow.BuildingBlocks;

namespace Api.Modules
{
    public class IndexModule : SecureModule
    {
        public IndexModule(IPbApiClient pbApiClient)
        {
            Post["/"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();
                var metaData = pbApiClient.Post<dynamic>(token, "getUserMetaData");

                return Response.AsJson((object)metaData);
            };

            Post["/action/{action}"] = parameters =>
            {

                return null;
            };

            Post["/license"] = parameters =>
            {
                var licRequest = this.Bind<LicensePlateNumberRequest>();
                var request = new LicensePlateNumberRequest();
                var entryPoint = new EntryPoint(new Workflow.RabbitMQ.Publisher(new BusFactory().CreateBus(""))); //TODO: Need to build functionality to create a bus and pass in IPublishMessages
                var responses = entryPoint.GetResponsesFromLace(request);

                return Response.AsJson(responses.First().Response);
            };
        }
    }
}