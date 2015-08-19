using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using Shared.Configuration;

namespace Shared.BuildingBlocks.Api.ApiClients
{
    public interface IApiClient
    {
        string Get(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, params KeyValuePair<string, string>[] headers);
        string Post(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null, params KeyValuePair<string, string>[] headers);
        T Get<T>(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, params KeyValuePair<string, string>[] headers) where T : new();
        T Post<T>(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null, params KeyValuePair<string, string>[] headers) where T : new();
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

        public T Get<T>(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, params KeyValuePair<string, string>[] headers) where T : new()
        {
            var request = RestRequest(token, resource, Method.GET, DataFormat.Json, null, headers);

            return _client.Execute<T>(request).Data;
        }

        public T Post<T>(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null, params KeyValuePair<string, string>[] headers) where T : new()
        {
            var request = RestRequest(token, resource, Method.POST, DataFormat.Json, parameters, body, headers);

            return _client.Execute<T>(request).Data;
        }

        public string Get(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, params KeyValuePair<string, string>[] headers)
        {
            var request = RestRequest(token, resource, Method.GET, DataFormat.Json, parameters, null, headers);
            return _client.Execute(request).Content;
        }

        public string Post(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null, params KeyValuePair<string, string>[] headers)
        {
            var request = RestRequest(token, resource, Method.POST, DataFormat.Json, parameters, body, headers);
            return _client.Execute(request).Content;
        }

        private static RestRequest RestRequest(string token, string resource = "", Method method = Method.GET, DataFormat dataFormat = DataFormat.Json, IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null, params KeyValuePair<string, string>[] headers)
        {
            var request = new RestRequest(resource, method);

            if (!string.IsNullOrEmpty(token))
                request.AddHeader("Authorization", "Token " + token);

            foreach (var valuePair in headers)
                request.AddHeader(valuePair.Key, valuePair.Value);

            parameters = parameters ?? Enumerable.Empty<KeyValuePair<string, string>>();
            foreach (var parameter in parameters)
                request.AddParameter(parameter.Key, parameter.Value);

            if (body != null)
            {
                request.RequestFormat = dataFormat;
                request.AddBody(body);
            }

            return request;
        }
    }
}