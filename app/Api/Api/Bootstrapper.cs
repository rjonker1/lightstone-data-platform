
using Api.Infrastructure.Automapping;
using Api.Infrastructure.Metadata;
using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Handlers;
using Api.Verfication.Infrastructure.Handlers.Contracts;
using Api.Verfication.Infrastructure.Services;
using Billing.Api.Connector;
using Billing.Api.Connector.Configuration;
using DataPlatform.Shared.Messaging.RabbitMQ;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.Routing;
using Nancy.TinyIoc;
using Shared.BuildingBlocks.Api.Security;

namespace Api
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            //var configuration = new StatelessAuthenticationConfiguration(context =>
            //{
            //    var token = context.AuthorizationHeaderToken();
            //    var authenticator = container.Resolve<IAuthenticateUser>();


            //    return string.IsNullOrWhiteSpace(token) ? null : authenticator != null ? authenticator.GetUserIdentity(token) : null;
            //});

            //StatelessAuthentication.Enable(pipelines, configuration);

            //TODO: Implement
            //pipelines.EnableStatelessAuthentication(container.Resolve<IAuthenticateUser>());
            //pipelines.EnableCors(); // cross origin resource sharing
            //pipelines.EnableMonitoring();

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

            AutoMapperConfiguration.Init();

            //container.Register<IAuthenticateUser, UmApiAuthenticator>();
            container.Register<IRouteMetadataProvider, DefaultRouteMetadataProvider>();
            container.Register<IRouteDescriptionProvider, ApiRouteDescriptionProvider>();

            var bus = new BusFactory("Monitoring.Messages.Commands").CreateBus();

            //container.Register(publisher);
            container.Register<IEntryPoint>(new EntryPointService(bus));

            //TODO: Implement
           // container.Register<IConnectToBilling>(new DefaultBillingConnector(new ApplicationConfigurationBillingConnectorConfiguration()));

            //verification
            container.Register<ICallFicaVerification, FicaVerificationService>();
            container.Register<IHandleFicaVerficationRequests, FicaVerificationHandler>();

            container.Register<ICallDriversLicenseVerification, DriversLicenseVerificationService>();
            container.Register<IHandleDriversLicenseVerficationRequests, DriversLicenseVerificationHandler>();
        }
    }
}