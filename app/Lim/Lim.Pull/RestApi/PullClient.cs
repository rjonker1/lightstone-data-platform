using System;
using Lim.Push.Extensions;
using RestSharp;

namespace Lim.Pull.RestApi
{
    public class PullClient : IDisposable
    {
        private bool _isDisposed;
        private RestClient _client;
        private readonly RestRequest _request;

        public bool IsSuccessful { get; private set; }

        private PullClient(string baseAddress, string suffix)
        {
            _client = baseAddress.ToRestClient();
            _request = new RestRequest(suffix, Method.GET);
        }

        private PullClient(string baseAddress, string suffix, string key, string token, string username, string password)
        {
            _client = baseAddress.ToRestClient();
            _request = new RestRequest(suffix, Method.GET);
            _client.Authenticator = new HttpBasicAuthenticator(username, password);
            _client.AddDefaultHeader(key, token);
        }

        private PullClient(string baseAddress, string suffix, string key, string token)
        {
            _client = baseAddress.ToRestClient();
            _request = new RestRequest(suffix, Method.GET);
            _client.AddDefaultHeader(key, token);
        }

        public static PullClient Pull(string baseAddress, string suffix)
        {
            return new PullClient(baseAddress, suffix);
        }

        public static PullClient PullWithBasic(string baseAddress, string suffix, string key, string token, string username,
            string password)
        {
            return new PullClient(baseAddress, suffix, key, token, username, password);
        }

        public static PullClient PullWithStateless(string baseAddress, string suffix, string key, string token)
        {
            return new PullClient(baseAddress, suffix, key, token);
        }

        public string Pull<T>(T model) where T : class
        {
            _request.RequestFormat = DataFormat.Json;
            _request.AddBody(model);
            var response = _client.Execute(_request);
            IsSuccessful = response.ResponseStatus == ResponseStatus.Completed && response.ContentLength > 0;
            return IsSuccessful ? response.Content : string.Empty;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool timeToDispose)
        {
            if (_isDisposed && !timeToDispose)
                return;

            _client = null;
            _isDisposed = true;
        }
    }
}
