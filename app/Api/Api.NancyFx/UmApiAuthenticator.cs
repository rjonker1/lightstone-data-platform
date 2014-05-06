using BuildingBlocks.Configuration;
using Nancy.Security;
using RestSharp;
using Shared.BuildingBlocks.Api.Security;

namespace Api.NancyFx
{
    public class UmApiAuthenticator : IUmApiAuthenticator
    {
        public IUserIdentity GetUserIdentity(string token)
        {
            var appSettings = new AppSettings();
            var client = new RestClient(appSettings.UmApi.BaseUrl);
            var request = new RestRequest(appSettings.UmApi.AuthenticationResource, Method.POST);
            client.AddHandler("application/json", new RestSharpDataContractJsonDeserializer());
            request.AddHeader("Authorization", "ApiKey " + token);

            return client.Execute<ApiUser>(request).Data;
        }
    }
}