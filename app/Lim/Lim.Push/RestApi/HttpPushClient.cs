using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Lim.Extensions;

namespace Lim.Push.RestApi
{
    public class HttpPushClient<T, TResource> : IDisposable where T : class
    {
        private bool _hasBeenDisposed;
        private HttpClient _client;
        private readonly string _suffix;

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

        public async Task<T> PostAsync(T model)
        {
            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            var content = new ObjectContent<T>(model, jsonFormatter);
            var response = await _client.PostAsync(_suffix, content);
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task PutAsync(TResource identifier, T model)
        {
            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            var content = new ObjectContent<T>(model, jsonFormatter);
            var response = await _client.PutAsync(_suffix + identifier, content);
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
