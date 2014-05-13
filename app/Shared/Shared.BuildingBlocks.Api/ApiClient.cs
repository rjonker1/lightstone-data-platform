using System.Collections.Generic;
using BuildingBlocks.Configuration;
using RestSharp;

namespace Shared.BuildingBlocks.Api
{
    public interface IApiClient
    {
        T Post<T>(string resource, string token, KeyValuePair<string, object>[] parameters = null) where T : new();
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

        public T Post<T>(string resource, string token, KeyValuePair<string, object>[] parameters = null) where T : new()
        {
            var request = RestRequest(resource, token, parameters);

            return _client.Execute<T>(request).Data;
        }

        public string Post(string resource, string token, KeyValuePair<string, object>[] parameters = null)
        {
            var request = RestRequest(resource, token, parameters);

            return _client.Execute(request).Content;
        }

        private static RestRequest RestRequest(string resource, string token, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            var request = new RestRequest(resource, Method.POST);
            request.AddHeader("Authorization", "ApiKey " + token);
            if (parameters == null) return request;
            foreach (var parameter in parameters)
                request.AddUrlSegment(parameter.Key, parameter.Value + "");

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