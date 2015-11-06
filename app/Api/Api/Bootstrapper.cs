using System;
using System.Configuration;
using Api.Domain.Core.Messages;
using Api.Domain.Infrastructure.Automapping;
using Api.Domain.Infrastructure.Bus;
using Api.Domain.Infrastructure.Extensions;
using Api.Domain.Infrastructure.Metadata;
using Api.Helpers.Installers;
using Api.Infrastructure.Metadata;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using EasyNetQ;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using Nancy.Hosting.Aspnet;
using Nancy.Routing;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.ExceptionHandling;
using Shared.BuildingBlocks.Api.Security;
using Workflow.BuildingBlocks;

namespace Api
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        public Bootstrapper()
        {
            Nancy.Json.JsonSettings.MaxJsonLength = int.MaxValue;
        }

        protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));

            pipelines.AfterRequest.AddItemToEndOfPipeline(nancyContext => this.Info(() => "Api invoked successfully at {0}[{1}]".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url)));
            pipelines.OnError.AddItemToEndOfPipeline((nancyContext, exception) =>
            {
                this.Error(() => "Error on Api request {0}[{1}] => {2}".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url, exception));
                var errorResponse = ErrorResponse.FromException(exception);
                if (exception is LightstoneAutoException)
                    errorResponse.StatusCode = HttpStatusCode.ImATeapot;

                return errorResponse;
            });

            //pipelines.EnableCors(); // cross origin resource sharing
            pipelines.AfterRequest.AddItemToEndOfPipeline(nancyContext =>
            {
                nancyContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");
            });
            pipelines.EnableMonitoring();

            Nancy.Json.JsonSettings.MaxJsonLength = int.MaxValue;
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            base.ConfigureApplicationContainer(container);

            AutoMapperConfiguration.Init();

            container.Install(
                new AuthInstaller(),
                new AutoMapperInstaller());

            container.Register(
                Component.For<IAuthenticateUser>().ImplementedBy<UerManagementAuthenticator>().LifestyleTransient());
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
            container.Register(Component.For<IAdvancedBus>().Instance(BusFactory.CreateAdvancedBus(ConfigurationManager.ConnectionStrings["api/bus/host"].ConnectionString)).LifestyleSingleton());
            container.Register(Component.For<IDispatchMessagesToBus<RequestMetadataMessage>>().ImplementedBy<RequestMessageDispatcher>().LifestyleSingleton());

        }

        protected override IRootPathProvider RootPathProvider
        {
            get { return new AspNetRootPathProvider(); }
        }
    }
}