using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace Api.NancyFx
{
    using Nancy;

    public class AuthenticationBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            var configuration = new StatelessAuthenticationConfiguration(nancyContext =>
            {
                const string key = "ApiKey ";
                string accessToken = null;

                if (nancyContext.Request.Headers.Authorization.StartsWith(key))
                    accessToken = nancyContext.Request.Headers.Authorization.Substring(key.Length);

                return string.IsNullOrWhiteSpace(accessToken) ? null : UserDatabase.GetUserFromApiKey(accessToken);
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
    }
}