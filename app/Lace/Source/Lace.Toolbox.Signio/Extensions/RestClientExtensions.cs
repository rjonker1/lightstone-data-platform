using System;
using RestSharp;

namespace Lace.Toolbox.Signio.Extensions
{
    public static class RestClientExtensions
    {
        public static IRestClient Setup(this IRestClient client, IConfiguration configuration)
        {
            if(client.BaseUrl == null)
                client.BaseUrl = new Uri(configuration.BaseUrl);

            if (client.Authenticator == null)
                client.Authenticator = configuration.Authenticator;

            client.AddDefaultHeader(configuration.Key, configuration.Token);

            return client;
        }
    }
}
