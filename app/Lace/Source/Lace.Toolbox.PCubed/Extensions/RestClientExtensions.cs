using System;
using RestSharp;

namespace Lace.Toolbox.PCubed.Extensions
{
    public static class RestClientExtensions
    {
        internal static IRestClient Setup(this IRestClient client, IConfiguration config)
        {
            if (client.BaseUrl == null)
                client.BaseUrl = new Uri(config.BaseUrl);

            if (client.Authenticator == null)
                client.Authenticator = config.Authenticator;

            if (string.IsNullOrEmpty(client.BaseUrl.AbsoluteUri))
                throw new NullReferenceException("The BaseUrl property cannot be empty for the RestClient.");

            return client;
        }
    }

}