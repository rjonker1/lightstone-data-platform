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
using Workflow.BuildingBlocks;

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
                return new Guid("1E660593-C11C-47B3-84DF-988F9FDFB0F1");
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
                var metaData = pbApiClient.Get<ApiMetaData>(token, "getUserMetaData");

                return Response.AsJson(metaData);
            };

            Post["/action/{action}"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();
                var packageResponse = pbApiClient.Get<Package>(token, "package/" + parameters.action);
                //var packageResponse = pbApiClient.Get<ExpandoObject>(token, "package/" + parameters.action);

                var package = Mapper.DynamicMap<IPackage>(packageResponse);
                //var package = DynamicToStatic.ToStatic<IPackage>(packageResponse);
                var vehicle = this.Bind<Vechicle>();
                var request = new LicensePlateNumberRequest(package, new User(), new Context(), vehicle, new AggregationInformation());
                var bus = BusFactory.CreateBus("monitor-event-tracking/queue");
                var publisher = new Workflow.RabbitMQ.Publisher(bus);
                var entryPoint = new EntryPoint(publisher); 
                var responses = entryPoint.GetResponsesFromLace(request);

                return Response.AsJson(responses.First().Response);
            };
        }

        public static class DynamicToStatic
        {
            public static T ToStatic<T>(object expando)
            {
                var entity = Mapper.DynamicMap<T>(expando);

                //ExpandoObject implements dictionary
                var properties = expando as IDictionary<string, object>;

                if (properties == null)
                    return entity;

                foreach (var entry in properties)
                {
                    var propertyInfo = entity.GetType().GetProperty(entry.Key);
                    if (propertyInfo != null)
                        propertyInfo.SetValue(entity, entry.Value, null);
                }
                return entity;
            }
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

    public class Action 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Criteria Criteria { get; set; }
    }

    public class Criteria 
    {
        public IEnumerable<DataField> Fields { get; set; }
    }

    public class ApiMetaData
    {
        public string Path { get; set; }
        public IEnumerable<Action> Actions { get; set; }
    }
}