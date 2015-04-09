using System;
using System.Collections.Generic;
using RestSharp;
using Shared.Configuration;

namespace Shared.BuildingBlocks.Api.ApiClients
{
    public interface IApiClient
    {
        string Get(string token, string resource = "", object body = null, params KeyValuePair<string, string>[] headers);
        string Post(string token, string resource = "", object body = null, params KeyValuePair<string, string>[] headers);
        T Get<T>(string token, string resource = "", object body = null, params KeyValuePair<string, string>[] headers) where T : new();
        T Post<T>(string token, string resource = "", object body = null, params KeyValuePair<string, string>[] headers) where T : new();
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

        private T Data<T>(string token, string resource, object body, Method method = Method.GET, params KeyValuePair<string, string>[] headers) where T : new()
        {
            var request = RestRequest(resource, token, body, method, headers);

            return _client.Execute<T>(request).Data;
        }

        public T Get<T>(string token, string resource = "", object body = null, params KeyValuePair<string, string>[] headers) where T : new()
        {
            return Data<T>(token, resource, body, Method.GET, headers);
        }

        public T Post<T>(string token, string resource = "", object body = null, params KeyValuePair<string, string>[] headers) where T : new()
        {
            return Data<T>(token, resource, body, Method.POST, headers);
        }

        private string Content(string token, string resource, object body, Method method = Method.GET, params KeyValuePair<string, string>[] headers)
        {
            var request = RestRequest(resource, token, body, method, headers);

            return _client.Execute(request).Content;
        }

        public string Get(string token, string resource = "", object body = null, params KeyValuePair<string, string>[] headers)
        {
            return Content(token, resource, body, Method.GET, headers);
        }

        public string Post(string token, string resource = "", object body = null, params KeyValuePair<string, string>[] headers)
        {
            return Content(token, resource, body, Method.POST, headers);
        }

        private static RestRequest RestRequest(string resource, string token, object body = null,
            Method method = Method.GET, params KeyValuePair<string, string>[] headers)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Authorization", "ApiKey " + token);
            foreach (var valuePair in headers)
                request.AddHeader(valuePair.Key, valuePair.Value);
            if (body != null)
                request.AddObject(body);

            return request;
        }
    }
}