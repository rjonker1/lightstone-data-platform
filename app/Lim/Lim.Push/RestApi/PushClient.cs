using System;
using Lim.Push.Extensions;
using RestSharp;

namespace Lim.Push.RestApi
{
    public class PushClient : IDisposable
    {
        private bool _isDisposed;
        private RestClient _client;
        private readonly RestRequest _request;

        public bool IsSuccessful { get; private set; }

        private PushClient(string baseAddress, string suffix)
        {
            _client = baseAddress.ToRestClient();
            _request = new RestRequest(suffix, Method.POST);
        }


        private PushClient(string baseAddress, string suffix, string key, string token, string username, string password)
        {
            _client = baseAddress.ToRestClient();
            _request = new RestRequest(suffix, Method.POST);
            _client.Authenticator = new HttpBasicAuthenticator(username, password);
            _client.AddDefaultHeader(key, token);
        }

        private PushClient(string baseAddress, string suffix, string key, string token)
        {
            _client = baseAddress.ToRestClient();
            _request = new RestRequest(suffix, Method.POST);
            _client.AddDefaultHeader(key, token);
        }

        public static PushClient Push(string baseAddress, string suffix)
        {
            return new PushClient(baseAddress, suffix);
        }

        public static PushClient PushWithBasic(string baseAddress, string suffix, string key, string token, string username,
            string password)
        {
            return new PushClient(baseAddress, suffix, key, token, username, password);
        }

        public static PushClient PushWithStateless(string baseAddress, string suffix, string key, string token)
        {
            return new PushClient(baseAddress, suffix, key, token);
        }

        public void Post<T>(T model) where T : class
        {
            _request.RequestFormat = DataFormat.Json;
            _request.AddBody(model);
            IsSuccessful = _client.Execute(_request).ResponseStatus == ResponseStatus.Completed;
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