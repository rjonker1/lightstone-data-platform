using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Lim.Extensions
{
    public static class HttpClientExtensions
    {
        private const string JsonMediaType = "application/json";

        public static HttpClient ToHttpClient(this string baseAddress)
        {
            if (string.IsNullOrEmpty(baseAddress))
                throw new Exception("Base Address for http client cannot be empty");

            var client = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress)
            };
            client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(JsonMediaType));
            client.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("defalte"));
            return client;
        }

        public static HttpClient ToHttpBasicClient(this string baseAddress, string key, string token, AuthenticationHeaderValue authentication)
        {
            if (string.IsNullOrEmpty(baseAddress))
                throw new Exception("Base Address for http client cannot be empty");

            var client = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress)
            };
            client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(JsonMediaType));
            client.DefaultRequestHeaders.Authorization = authentication;
            client.DefaultRequestHeaders.Add(key, token);
            return client;
        }
    }
}