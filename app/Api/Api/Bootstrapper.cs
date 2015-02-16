using Api.Domain.Infrastructure.Automapping;
using Api.Domain.Infrastructure.Extensions;
using Api.Domain.Verification.Core.Contracts;
using Api.Domain.Verification.Infrastructure.Handlers;
using Api.Domain.Verification.Infrastructure.Handlers.Contracts;
using Api.Domain.Verification.Infrastructure.Services;
using Api.Infrastructure.Metadata;
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
using NServiceBus;
using Shared.BuildingBlocks.Api;
using Shared.BuildingBlocks.Api.Security;


namespace Api
{
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

            pipelines.EnableStatelessAuthentication(container.Resolve<IAuthenticateUser>());
            pipelines.EnableCors(); // cross origin resource sharing
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
            base.ConfigureApplicationContainer(container);

            AutoMapperConfiguration.Init();

            container.Register<IAuthenticateUser, UmApiAuthenticator>();
            container.Register<IRouteMetadataProvider, DefaultRouteMetadataProvider>();
            container.Register<IRouteDescriptionProvider, ApiRouteDescriptionProvider>();

            container.Register<IPackageBuilderApiClient, PackageBuilderApiClient>();
            container.Register<IUserManagementApiClient, UserManagementApiClient>();

            var assembliesToScan = AllAssemblies.Matching("Lightstone.DataPlatform.Lace.Shared.Monitoring.Messages").And("NServiceBus.NHibernate").And("NServiceBus.Transports.RabbitMQ");

            container.Register<IBus>(new BusFactory("Monitoring.Messages.Commands", assembliesToScan, "DataPlatform.Monitoring.Host").CreateBus());
            container.Register<IEntryPoint, EntryPointService>();

            container.Register<IConnectToBilling>(new DefaultBillingConnector(new ApplicationConfigurationBillingConnectorConfiguration()));

            container.Register<ICallFicaVerification, FicaVerificationService>();
            container.Register<IHandleFicaVerficationRequests, FicaVerificationHandler>();

            container.Register<ICallDriversLicenseVerification, DriversLicenseVerificationService>();
            container.Register<IHandleDriversLicenseVerficationRequests, DriversLicenseVerificationHandler>();
        }


    }
}