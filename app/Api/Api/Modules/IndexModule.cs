using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Public.Entities;
using EasyNetQ;
using Lace.Request;
using Lace.Request.Entry;
using Nancy;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Modules
{
    public class FakeBus : IBus
    {
        public IAdvancedBus Advanced
        {
            get { throw new System.NotImplementedException(); }
        }

        public event System.Action Connected;

        public event System.Action Disconnected;

        public bool IsConnected
        {
            get { throw new System.NotImplementedException(); }
        }

        public void Publish<T>(T message, string topic) where T : class
        {

        }

        public void Publish<T>(T message) where T : class
        {

        }

        public System.Threading.Tasks.Task PublishAsync<T>(T message, string topic) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task PublishAsync<T>(T message) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable Receive(string queue, System.Action<EasyNetQ.Consumer.IReceiveRegistration> addHandlers)
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable Receive<T>(string queue, System.Func<T, System.Threading.Tasks.Task> onMessage) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable Receive<T>(string queue, System.Action<T> onMessage) where T : class
        {
            throw new System.NotImplementedException();
        }

        public TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable Respond<TRequest, TResponse>(System.Func<TRequest, TResponse> responder)
            where TRequest : class
            where TResponse : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable RespondAsync<TRequest, TResponse>(System.Func<TRequest, System.Threading.Tasks.Task<TResponse>> responder)
            where TRequest : class
            where TResponse : class
        {
            throw new System.NotImplementedException();
        }

        public void Send<T>(string queue, T message) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable Subscribe<T>(string subscriptionId, System.Action<T> onMessage, System.Action<EasyNetQ.FluentConfiguration.ISubscriptionConfiguration> configure) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable Subscribe<T>(string subscriptionId, System.Action<T> onMessage) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable SubscribeAsync<T>(string subscriptionId, System.Func<T, System.Threading.Tasks.Task> onMessage, System.Action<EasyNetQ.FluentConfiguration.ISubscriptionConfiguration> configure) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable SubscribeAsync<T>(string subscriptionId, System.Func<T, System.Threading.Tasks.Task> onMessage) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }

    public class AggregationInformation : IProvideRequestAggregation
    {
        public Guid AggregateId
        {
            get
            {
                return Guid.NewGuid();
            }
        }
    }
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
                var request = new LicensePlateNumberRequest(package, new User(), new Context(), vehicle, new AggregationInformation());
                //var entryPoint = new EntryPoint(new Workflow.RabbitMQ.Publisher(new BusFactory().CreateBus("workflow/api/queue", new WindsorContainer()))); //TODO: Need to build functionality to create a bus and pass in IPublishMessages
                var bus = new FakeBus();
                var publisher = new Workflow.RabbitMQ.Publisher(bus);
                var entryPoint = new EntryPoint(publisher); //TODO: Need to build functionality to create a bus and pass in IPublishMessages
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