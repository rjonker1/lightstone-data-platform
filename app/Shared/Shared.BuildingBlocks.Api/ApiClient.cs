using BuildingBlocks.Configuration;
using RestSharp;

namespace Shared.BuildingBlocks.Api
{
    public interface IApiClient
    {
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

        public T Post<T>(string resource, string token, object body = null) where T : new()
        {
            var request = RestRequest(resource, token, body);

            return _client.Execute<T>(request).Data;
        }

        public string Post(string resource, string token, object body = null)
        {
            var request = RestRequest(resource, token, body);

            return _client.Execute(request).Content;
        }

        private static RestRequest RestRequest(string resource, string token, object body = null)
        {
            var request = new RestRequest(resource, Method.POST);
            request.AddHeader("Authorization", "ApiKey " + token);
            if (body != null) 
                request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
            return request;
        }
    }

    public class ApiClient : ApiClientBase
    {
        public ApiClient() : base(AppSettings.Api.BaseUrl) { }
    }

    public class UmApiClient : ApiClientBase
    {
        public UmApiClient() : base(AppSettings.UmApi.BaseUrl) { }
    }
}