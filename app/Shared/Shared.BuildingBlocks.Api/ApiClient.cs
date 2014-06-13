using BuildingBlocks.Configuration;
using RestSharp;

namespace Shared.BuildingBlocks.Api
{
    public interface IApiClient
    {
        string Get(string token, string resource = "", object body = null);
        string Post(string token, string resource = "", object body = null);
        T Get<T>(string resource, string token, object body = null) where T : new();
        T Post<T>(string resource, string token, object body = null) where T : new();
    }

    public interface IUmApiClient : IApiClient
    {

    }

    public interface IPbApiClient : IApiClient
    {
        string Get(string token, string resource = "", object body = null);
        string Post(string token, string resource = "", object body = null);
        T Get<T>(string resource, string token, object body = null) where T : new();
        T Post<T>(string resource, string token, object body = null) where T : new();
    }

    public abstract class ApiClientBase : IApiClient
    {
        protected static readonly AppSettings AppSettings = new AppSettings();
        private readonly RestClient _client;

        protected ApiClientBase(string baseUrl)
        {
            //ToDo: Null checking
            _client = new RestClient(baseUrl);
            _client.AddHandler("application/json", new RestSharpDataContractJsonDeserializer());
        }

        private T Data<T>(string token, string resource, object body, Method method = Method.GET) where T : new()
        {
            var request = RestRequest(resource, token, body, method);

            return _client.Execute<T>(request).Data;
        }

        public T Get<T>(string token, string resource = "", object body = null) where T : new()
        {
            return Data<T>(token, resource, body);
        }

        public T Post<T>(string token, string resource = "", object body = null) where T : new()
        {
            return Data<T>(token, resource, body, Method.POST);
        }

        private string Content(string token, string resource, object body, Method method = Method.GET)
        {
            var request = RestRequest(resource, token, body, method);

            return _client.Execute(request).Content;
        }

        public string Get(string token, string resource = "", object body = null)
        {
            return Content(token, resource, body);
        }

        public string Post(string token, string resource = "", object body = null)
        {
            return Content(token, resource, body, Method.POST);
        }

        private static RestRequest RestRequest(string resource, string token, object body = null, Method method = Method.GET)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Authorization", "ApiKey " + token);
            if (body != null)
                request.AddObject(body);

            return request;
        }
    }

    public class ApiClient : ApiClientBase
    {
        public ApiClient() : base(AppSettings.Api.BaseUrl) { }
    }

    public class UmApiClient : ApiClientBase, IUmApiClient
    {
        public UmApiClient() : base(AppSettings.UmApi.BaseUrl) { }
    }

    public class PbApiClient : ApiClientBase, IPbApiClient
    {
        public PbApiClient() : base(AppSettings.PbApi.BaseUrl) { }
    }
}