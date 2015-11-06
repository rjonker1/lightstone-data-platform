using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
﻿using Lim.Core;
using Lim.Domain.Dto;
using Lim.Domain.Entities.Repository;
using Lim.Web.UI.Commits;
using Lim.Web.UI.Handlers;
using Lim.Web.UI.Models.Api;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using Nancy.Conventions;
using Nancy.Helpers;
using Nancy.Hosting.Aspnet;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.ExceptionHandling;
using Shared.BuildingBlocks.Api.Installers;

namespace Lim.Web.UI
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            get { return new AspNetRootPathProvider(); }
        }

        protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
        {
            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));
            StaticConfiguration.DisableErrorTraces = false;
            base.ApplicationStartup(container, pipelines);
        }

        protected override void RequestStartup(IWindsorContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.BeforeRequest.AddItemToEndOfPipeline(nancyContext =>
            {
                this.Info(() => "LIM WEB invoked at {0}[{1}]".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url));
                var token = "";
                var cookie = nancyContext.Request.Headers.Cookie.FirstOrDefault(x => (x.Name + "").ToLower() == "token");
                if (cookie != null)
                    token = HttpUtility.UrlDecode(cookie.Value);

                nancyContext.Request.Headers.Authorization = "Token {0}".FormatWith(token);

                var user = container.Resolve<ITokenizer>().Detokenize(token, nancyContext, new DefaultUserIdentityResolver());
                if (user != null)
                {
                    nancyContext.CurrentUser = user;
                }
                return null;
            });

            pipelines.OnError.AddItemToEndOfPipeline((nancyContext, exception) =>
            {
                this.Error(() => "Error on LIM request {0}[{1}] => {2}".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url, exception));
                return ErrorResponse.FromException(exception);
            });
            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));

            pipelines.OnError.AddItemToEndOfPipeline((nancyContext, exception) =>
            {
                this.Error(() => "Error on LIM request {0}[{1}] => {2}".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url, exception));
                return ErrorResponse.FromException(exception);
            });
            base.RequestStartup(container, pipelines, context);
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            container.Register(Component.For<IRepository, LimRepository>());
            container.Register(Component.For<IUserManagementApiClient, UserManagementApiClient>());
            container.Register(Component.For<ISaveApiConfiguration, SaveApiConfiguration>());
            container.Register(Component.For<IHandleGettingDataPlatformClient, GetDataPlatformClientHandler>());
            container.Register(Component.For<IHandleGettingIntegrationClient, GetIntegrationClientHandler>());
            container.Register(Component.For<IHandleGettingConfiguration, GetConfigurationHandler>());
            container.Register(Component.For<IHandleSavingConfiguration, SavingConfigurationHandler>());
            container.Register(Component.For<IHandleSavingClient, SavingClientHandler>());
            container.Register(Component.For<IHandleGettingMetadata, GetMetadataHandler>());
            container.Register(Component.For<IPersist<PushConfiguration>, ApiPushCommit>());
            container.Register(Component.For<IPersist<ClientDto>, ClientCommit>());

            container.Install(new AuthInstaller());
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/js"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/js/pages"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/images"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/img"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/css"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/css/skins"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/ang"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/jquery"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/plugins"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/plugins/fastclick"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/plugins/slimScroll"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/plugins/timepicker"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/plugins/daterangepicker"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/plugins/input-mask"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/plugins/chosen"));
        }
    }
}