using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Lim.Extensions;

namespace Lim.Pull.RestApi
{
    public class HttpPullClient<T, TResource> : IDisposable where T : class
    {
        private bool _hasBeenDisposed;
        private HttpClient _client;
        private readonly string _suffix;


        public HttpPullClient(string baseAddress, string suffix)
        {
            _suffix = suffix;
            _client = baseAddress.ToHttpClient();
        }

        public async Task<IEnumerable<T>> GetManyAsync()
        {
            var message = await _client.GetAsync(_suffix);
            message.EnsureSuccessStatusCode();
            return await message.Content.ReadAsAsync<IEnumerable<T>>();
        }

        public async Task<T> GetAsync(TResource identifier)
        {
            var message = await _client.GetAsync(_suffix + identifier);
            message.EnsureSuccessStatusCode();
            return await message.Content.ReadAsAsync<T>();
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
