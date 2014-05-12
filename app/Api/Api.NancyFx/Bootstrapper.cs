using AutoMapper;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Newtonsoft.Json;
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
                var authenticator = container.Resolve<IAuthenticateUser>();

                return string.IsNullOrWhiteSpace(token) ? null : authenticator != null ? authenticator.GetUserIdentity(token) : null;
            });

            StatelessAuthentication.Enable(pipelines, configuration);

            pipelines.EnableMonitoring();

            //Make every request SSL based
            //pipelines.BeforeRequest += ctx =>
            //{
            //    return (!ctx.Request.Url.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase)) ?
            //        (Response)HttpStatusCode.Unauthorized :
            //        null;
            //};
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            // Perform registation that should have an application lifetime
            base.ConfigureApplicationContainer(container);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Request, IRequest>();
                cfg.CreateMap<Response, IResponse>()
                    .ForMember(d => d.Response, opt => opt.MapFrom<string>(s => JsonConvert.SerializeObject(s.Contents.Target)));
            });

            container.Register<IAuthenticateUser, UmApiAuthenticator>();
        }
    }
}