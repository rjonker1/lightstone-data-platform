using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using Shared.Configuration;

namespace Shared.BuildingBlocks.Api.ApiClients
{
    public interface IApiClient
    {
        string Get(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, params KeyValuePair<string, string>[] headers);
        Task<string> GetAsync(string authToken, CancellationToken token, string resource, IEnumerable<KeyValuePair<string, string>> parameters, params KeyValuePair<string, string>[] headers);
        string Post(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null, params KeyValuePair<string, string>[] headers);
        Task<string> PostAsync(string authToken, CancellationToken token, string resource, IEnumerable<KeyValuePair<string, string>> parameters, object body, params KeyValuePair<string, string>[] headers);
        string Put(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null, params KeyValuePair<string, string>[] headers);
        Task<string> PutAsync(string authToken, CancellationToken token, string resource, IEnumerable<KeyValuePair<string, string>> parameters, object body, params KeyValuePair<string, string>[] headers);
        T Get<T>(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, params KeyValuePair<string, string>[] headers) where T : new();
        Task<T> GetAsync<T>(string authToken, CancellationToken token, string resource, IEnumerable<KeyValuePair<string, string>> parameters, params KeyValuePair<string, string>[] headers) where T : new();
        T Post<T>(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null, params KeyValuePair<string, string>[] headers) where T : new();
        Task<T> PostAsync<T>(string authToken, CancellationToken token, string resource, IEnumerable<KeyValuePair<string, string>> parameters, object body, params KeyValuePair<string, string>[] headers) where T : new();
        T Put<T>(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null, params KeyValuePair<string, string>[] headers) where T : new();
        Task<T> PutAsync<T>(string authToken, CancellationToken token, string resource, IEnumerable<KeyValuePair<string, string>> parameters, object body, params KeyValuePair<string, string>[] headers) where T : new();
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
            var request = RestRequest(token, resource, Method.GET, DataFormat.Json, parameters, null, headers);

            return _client.Execute<T>(request).Data;
        }

        public async Task<T> GetAsync<T>(string authToken, CancellationToken token, string resource, IEnumerable<KeyValuePair<string, string>> parameters, params KeyValuePair<string, string>[] headers) where T : new()
        {
            var request = RestRequest(authToken, resource, Method.GET, DataFormat.Json, parameters, null, headers);
            var executeGetTaskAsync = await _client.ExecuteGetTaskAsync<T>(request, token);

            return executeGetTaskAsync.Data;
        }

        public T Post<T>(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null, params KeyValuePair<string, string>[] headers) where T : new()
        {
            var request = RestRequest(token, resource, Method.POST, DataFormat.Json, parameters, body, headers);

            return _client.Execute<T>(request).Data;
        }

        public async Task<T> PostAsync<T>(string authToken, CancellationToken token, string resource, IEnumerable<KeyValuePair<string, string>> parameters, object body, params KeyValuePair<string, string>[] headers) where T : new()
        {
            var request = RestRequest(authToken, resource, Method.POST, DataFormat.Json, parameters, body, headers);
            var executePostTaskAsync = await _client.ExecutePostTaskAsync<T>(request, token);

            return executePostTaskAsync.Data;
        }

        public T Put<T>(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null,
            params KeyValuePair<string, string>[] headers) where T : new()
        {
            var request = RestRequest(token, resource, Method.PUT, DataFormat.Json, parameters, body, headers);

            return _client.Execute<T>(request).Data;
        }

        public async Task<T> PutAsync<T>(string authToken, CancellationToken token, string resource, IEnumerable<KeyValuePair<string, string>> parameters, object body, params KeyValuePair<string, string>[] headers) where T : new()
        {
            var request = RestRequest(authToken, resource, Method.PUT, DataFormat.Json, parameters, body, headers);
            var executePostTaskAsync = await _client.ExecutePostTaskAsync<T>(request, token);

            return executePostTaskAsync.Data;
        }

        public string Get(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, params KeyValuePair<string, string>[] headers)
        {
            var request = RestRequest(token, resource, Method.GET, DataFormat.Json, parameters, null, headers);

            return _client.Execute(request).Content;
        }

        public async Task<string> GetAsync(string authToken, CancellationToken token, string resource, IEnumerable<KeyValuePair<string, string>> parameters, params KeyValuePair<string, string>[] headers)
        {
            var request = RestRequest(authToken, resource, Method.GET, DataFormat.Json, parameters, null, headers);
            var executeGetTaskAsync = await _client.ExecuteGetTaskAsync(request, token);

            return executeGetTaskAsync.Content;
        }

        public string Post(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null, params KeyValuePair<string, string>[] headers)
        {
            var request = RestRequest(token, resource, Method.POST, DataFormat.Json, parameters, body, headers);
            return _client.Execute(request).Content;
        }

        public async Task<string> PostAsync(string authToken, CancellationToken token, string resource, IEnumerable<KeyValuePair<string, string>> parameters, object body, params KeyValuePair<string, string>[] headers)
        {
            var request = RestRequest(authToken, resource, Method.POST, DataFormat.Json, parameters, body, headers);
            var executePostTaskAsync = await _client.ExecutePostTaskAsync(request, token);

            return executePostTaskAsync.Content;
        }

        public string Put(string token, string resource = "", IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null,
            params KeyValuePair<string, string>[] headers)
        {
            var request = RestRequest(token, resource, Method.PUT, DataFormat.Json, parameters, body, headers);
            return _client.Execute(request).Content;
        }

        public async Task<string> PutAsync(string authToken, CancellationToken token, string resource, IEnumerable<KeyValuePair<string, string>> parameters, object body, params KeyValuePair<string, string>[] headers)
        {
            var request = RestRequest(authToken, resource, Method.PUT, DataFormat.Json, parameters, body, headers);
            var executePostTaskAsync = await _client.ExecutePostTaskAsync(request, token);

            return executePostTaskAsync.Content;
        }

        private static RestRequest RestRequest(string token, string resource = "", Method method = Method.GET, DataFormat dataFormat = DataFormat.Json, IEnumerable<KeyValuePair<string, string>> parameters = null, object body = null, params KeyValuePair<string, string>[] headers)
        {
            var request = new RestRequest(resource, method);

            if (!string.IsNullOrEmpty(token))
                request.AddHeader("Authorization", "Token " + token);

            if (headers != null)
                foreach (var valuePair in headers)
                    request.AddHeader(valuePair.Key, valuePair.Value);
            
            parameters = parameters ?? Enumerable.Empty<KeyValuePair<string, string>>();
            foreach (var parameter in parameters)
                request.AddUrlSegment(parameter.Key, parameter.Value);

            if (body != null)
            {
                request.RequestFormat = dataFormat;
                request.AddBody(body);
            }

            return request;
        }
    }
}