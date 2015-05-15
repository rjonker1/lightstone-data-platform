using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Lim.Extensions;

namespace Lim.Push.RestApi
{
    public interface IHttpPushClient<T, TResponse> : IDisposable where T : class
    {
        Task<TResponse> PostAsync(T model);
        void PostWithNoResponse(T model);
        Task PutAsync(TResponse identifier, T model);
    }

    public class HttpPushClient<T, TResponse> : IDisposable where T : class
    {
        private bool _hasBeenDisposed;
        private HttpClient _client;
        private readonly string _suffix;
        public bool IsSuccessful { get; private set; }

        public HttpPushClient(string baseAddress, string suffix)
        {
            _suffix = suffix;
            _client = baseAddress.ToHttpClient();
        }

        public HttpPushClient(string baseAddress, string suffix, string key, string token, AuthenticationHeaderValue authentication)
        {
            _suffix = suffix;
            _client = baseAddress.ToHttpBasicClient(key, token, authentication);
        }

        public async Task<TResponse> PostAsync(T model)
        {
            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            var content = new ObjectContent<T>(model, jsonFormatter);
            //var response = await _client.PostAsync(_suffix, content);
            var response = _client.PostAsync(_suffix, content).Result;
            IsSuccessful = response.IsSuccessStatusCode;
            return await response.Content.ReadAsAsync<TResponse>();
        }

        public void PostWithNoResponse(T model)
        {
            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            var content = new ObjectContent<T>(model, jsonFormatter);
            //var response = await _client.PostAsync(_suffix, content);
            var response = _client.PostAsync(_suffix, content).Result;
            IsSuccessful = response.IsSuccessStatusCode;
        }

        public async Task PutAsync(TResponse identifier, T model)
        {
            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            var content = new ObjectContent<T>(model, jsonFormatter);
            var response = await _client.PutAsync(_suffix, content);
            IsSuccessful = response.IsSuccessStatusCode;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool timeToDispose)
        {
            if (_hasBeenDisposed && !timeToDispose)
                return;

            if (_client != null)
            {
                var fakeClient = _client;
                _client = null;
                fakeClient.Dispose();
            }
            _hasBeenDisposed = true;
        }
    }
}
