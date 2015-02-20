using System;
using RestSharp;
using Shared.Configuration;

namespace Shared.BuildingBlocks.Api.ApiClients
{
    public interface IApiClient
    {
        string Get(string token, string resource = "", object body = null);
        string Post(string token, string resource = "", object body = null);
        T Get<T>(string token, string resource = "", object body = null) where T : new();
        T Post<T>(string token, string resource = "", object body = null) where T : new();
    }

    public abstract class ApiClientBase : IApiClient
    {
        protected static readonly AppSettings AppSettings = new AppSettings();
        private readonly RestClient _client;

        protected ApiClientBase(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
                throw new Exception("baseUrl is missing");

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

        private static RestRequest RestRequest(string resource, string token, object body = null,
            Method method = Method.GET)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Authorization", "ApiKey " + token);
            if (body != null)
                request.AddObject(body);

            return request;
        }
    }
}