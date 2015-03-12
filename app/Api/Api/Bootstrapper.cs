using Api.Domain.Infrastructure.Automapping;
using Api.Domain.Infrastructure.Billing;
using Api.Domain.Infrastructure.Extensions;
using Api.Domain.Infrastructure.Metadata;
using Api.Domain.Verification.Core.Contracts;
using Api.Domain.Verification.Infrastructure.Handlers;
using Api.Domain.Verification.Infrastructure.Handlers.Contracts;
using Api.Domain.Verification.Infrastructure.Services;
using Api.Infrastructure.Metadata;
using Billing.Api.Connector;
using Billing.Api.Connector.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DataPlatform.Shared.Messaging.RabbitMQ;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using Nancy.Routing;
using NServiceBus;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;

namespace Api
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            var configuration = new StatelessAuthenticationConfiguration(context =>
            {
                var token = context.AuthorizationHeaderToken();
                var authenticator = container.Resolve<IAuthenticateUser>();
                return string.IsNullOrWhiteSpace(token)
                    ? null
                    : authenticator != null ? authenticator.GetUserIdentity(token) : null;
            });

          //  StatelessAuthentication.Enable(pipelines, configuration);

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

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            base.ConfigureApplicationContainer(container);

            AutoMapperConfiguration.Init();

            container.Register(
                Component.For<IAuthenticateUser>().ImplementedBy<UerManagementAuthenticator>().LifestyleTransient());
            //container.Register(Component.For<IRouteMetadataProvider>().ImplementedBy<DefaultRouteMetadataProvider>().LifestyleTransient());
            container.Register(
                Component.For<IRouteDescriptionProvider>()
                    .ImplementedBy<ApiRouteDescriptionProvider>()
                    .LifestyleTransient());
            container.Register(
                Component.For<IApiMetaDataGenerator>().ImplementedBy<ApiMetaDataGenerator>().LifestyleTransient());


            container.Register(
                Component.For<IPackageBuilderApiClient>().ImplementedBy<PackageBuilderApiClient>().LifestyleTransient());
            container.Register(
                Component.For<IUserManagementApiClient>().ImplementedBy<UserManagementApiClient>().LifestyleTransient());
            container.Register(
                Component.For<IUserAuthenticationClient>().ImplementedBy<UserAuthenticatorClient>().LifestyleTransient());

            var assembliesToScan =
                AllAssemblies.Matching("Lightstone.DataPlatform.Lace.Shared.Monitoring.Messages")
                    .And("NServiceBus.NHibernate")
                    .And("NServiceBus.Transports.RabbitMQ");

            container.Register(
                Component.For<IBus>()
                    .Instance(
                        new BusFactory("Monitoring.Messages.Commands", assembliesToScan, "DataPlatform.Monitoring.Host")
                            .CreateBusWithNHibernatePersistence()));
            container.Register(Component.For<IEntryPoint>().ImplementedBy<EntryPointService>().LifestyleTransient());


            container.Register(
                Component.For<IConnectToBilling>()
                    .Instance(new DefaultBillingConnector(new ApplicationConfigurationBillingConnectorConfiguration())));
            container.Register(
                Component.For<ICreateBillingTransaction>()
                    .ImplementedBy<CreateBillingTransaction>()
                    .LifestyleTransient());

            container.Register(
                Component.For<ICallFicaVerification>().ImplementedBy<FicaVerificationService>().LifestyleTransient());
            container.Register(
                Component.For<IHandleFicaVerficationRequests>()
                    .ImplementedBy<FicaVerificationHandler>()
                    .LifestyleTransient());

            container.Register(
                Component.For<ICallDriversLicenseVerification>()
                    .ImplementedBy<DriversLicenseVerificationService>()
                    .LifestyleTransient());
            container.Register(
                Component.For<IHandleDriversLicenseVerficationRequests>()
                    .ImplementedBy<DriversLicenseVerificationHandler>()
                    .LifestyleTransient());
        }
    }
}