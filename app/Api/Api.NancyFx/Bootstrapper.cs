using BuildingBlocks.Configuration;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.Security;
using Nancy.TinyIoc;
using RestSharp;
using Shared.BuildingBlocks.Api.Security;

namespace Api.NancyFx
{
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            var configuration = new StatelessAuthenticationConfiguration(context =>
            {
                var token = context.AuthorizationHeaderToken();

                return string.IsNullOrWhiteSpace(token) ? null : GetUser(token);
            });

            StatelessAuthentication.Enable(pipelines, configuration);

            //Make every request SSL based
            //pipelines.BeforeRequest += ctx =>
            //{
            //    return (!ctx.Request.Url.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase)) ?
            //        (Response)HttpStatusCode.Unauthorized :
            //        null;
            //};
        }

        private static IUserIdentity GetUser(string token)
        {
            //ToDo: Retry authentication on failure
            var appSettings = new AppSettings();
            var client = new RestClient(appSettings.UmApi.BaseUrl);
            var request = new RestRequest(appSettings.UmApi.AuthenticationResource, Method.POST);
            request.AddHeader("Authorization", "ApiKey " + token);
            // Json not serialized when Claims is initialized as empty collection for some reason
            return client.Execute<ApiUser>(request).Data;
        }
    }
}