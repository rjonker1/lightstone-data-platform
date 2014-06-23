using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.Entities;
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
            Get["/"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();
                var metaData = pbApiClient.Get<ApiMetaData>(token, "getUserMetaData");

                return Response.AsJson(metaData);
            };

            Post["/action/{action}"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();
                var packageResponse = pbApiClient.Get<Package>(token, "package/" + parameters.action);

                var package = Mapper.DynamicMap<IPackage>(packageResponse);
                var vehicle = this.Bind<Vechicle>();
                var request = new LicensePlateNumberRequest(package, new User(), new Context(), vehicle, new AggregationInformation());
                var bus = BusFactory.CreateBus("monitor-event-tracking/queue");
                var publisher = new Workflow.RabbitMQ.Publisher(bus);
                var entryPoint = new EntryPoint(publisher);
                var responses = entryPoint.GetResponsesFromLace(request);

                return Response.AsJson(responses.First().Response);
            };
        }
    }
}