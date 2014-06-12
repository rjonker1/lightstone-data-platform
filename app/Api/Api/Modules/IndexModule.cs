using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using DataPlatform.Shared.Public.Entities;
using Lace.Request.Entry;
using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;
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
                var metaData = pbApiClient.Get<dynamic>(token, "getUserMetaData");

                return Response.AsJson((object)metaData);
            };

            Post["/action/{action}"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();
                var packageResponse = pbApiClient.Get<Package>(token, "package/" + parameters.action);

                var package = Mapper.DynamicMap<IPackage>(packageResponse);

                var vehicle = this.Bind<Vechicle>();
                var request = new LicensePlateNumberRequest(package, null, null, vehicle, null);
                var entryPoint = new EntryPoint(new Workflow.RabbitMQ.Publisher(new BusFactory().CreateBus("", new WindsorContainer()))); //TODO: Need to build functionality to create a bus and pass in IPublishMessages
                var responses = entryPoint.GetResponsesFromLace(request);

                return Response.AsJson(responses.First().Response);
            };

            //Get["/license"] = parameters =>
            //{
            //    var vehicle = this.Bind<Vechicle>();
            //    var request = new LicensePlateNumberRequest(null, null, null, vehicle, null);
            //    var entryPoint = new EntryPoint(new Workflow.RabbitMQ.Publisher(new BusFactory().CreateBus(""))); //TODO: Need to build functionality to create a bus and pass in IPublishMessages
            //    var responses = entryPoint.GetResponsesFromLace(request);

            //    return Response.AsJson(responses.First().Response);
            //};
        }
    }

    public class Package 
    {
        public IEnumerable<DataSet> DataSets { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class DataSet 
    {
        public IEnumerable<DataField> DataFields { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class DataField 
    {
        public string Type { get; set; }
        public DataSource DataSource { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class DataSource
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}