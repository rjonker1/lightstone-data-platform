using System;
using System.Configuration;
using DataPlatform.Shared.Helpers.Extensions;
﻿using Lim.Core;
using Lim.Domain.Dto;
using Lim.Domain.Entities.Repository;
using Lim.Web.UI.Commits;
using Lim.Web.UI.Handlers;
using Lim.Web.UI.Models.Api;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Authentication.Token.Storage;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.ExceptionHandling;

namespace Lim.Web.UI
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            get { return new TokenRootPathProvider(); }
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));
            StaticConfiguration.DisableErrorTraces = false;
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.OnError.AddItemToEndOfPipeline((nancyContext, exception) =>
            {
                this.Error(() => "Error on Api request {0}[{1}] => {2}".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url, exception));
                return ErrorResponse.FromException(exception);
            });
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            var userAgent = ConfigurationManager.AppSettings["TokenAuthUserAgentValue"];
            container.Register<ITokenizer>(new Tokenizer(cfg => cfg.AdditionalItems(ctx => ctx.Request.Headers.UserAgent = userAgent).WithKeyCache(new FileSystemTokenKeyStore((new TokenRootPathProvider())))));

            container.Register<IRepository, LimRepository>();
            container.Register<IUserManagementApiClient, UserManagementApiClient>();
            container.Register<ISaveApiConfiguration, SaveApiConfiguration>();
            container.Register<IHandleGettingDataPlatformClient, GetDataPlatformClientHandler>();
            container.Register<IHandleGettingIntegrationClient, GetIntegrationClientHandler>();
            container.Register<IHandleGettingConfiguration, GetConfigurationHandler>();
            container.Register<IHandleSavingConfiguration, SavingConfigurationHandler>();
            container.Register<IHandleSavingClient, SavingClientHandler>();
            container.Register<IHandleGettingMetadata, GetMetadataHandler>();
            container.Register<IPersist<PushConfiguration>, ApiPushCommit>();
            container.Register<IPersist<ClientDto>, ClientCommit>();
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

        public class TokenRootPathProvider : IRootPathProvider
        {
            public string GetRootPath()
            {
                var keyStore = ConfigurationManager.AppSettings["TokenAuthKeyStorePath"];
                return new Uri(keyStore).LocalPath;
            }
        }
    }
}