using System;
using RestSharp;

namespace Lim.Push.Extensions
{
    public static class RestClientExtensions
    {
        private const string JsonMediaType = "application/json";
        private const string XmlMediaType = "application/xml";
        private const string HtmlMediaType = "text/html";

        private const string GZipEncodingType = "gzip";
        private const string DeflateEncodingType = "defalte";

        public static RestClient ToRestClient(this string baseAddress)
        {
            if(string.IsNullOrEmpty(baseAddress))
                throw new Exception("Base Address for http client cannot be empty");

            var client = new RestClient(baseAddress);
            client.AddDefaultHeader("Accept", JsonMediaType);
            client.AddDefaultHeader("Accept", XmlMediaType);
            client.AddDefaultHeader("Accept", HtmlMediaType);
            client.AddDefaultHeader("AcceptEncoding", GZipEncodingType);
            client.AddDefaultHeader("AcceptEncoding", DeflateEncodingType);
            return client;
        }
    }
}
