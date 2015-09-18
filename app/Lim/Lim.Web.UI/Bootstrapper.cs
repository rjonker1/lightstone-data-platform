using Lim.Core;
using Lim.Domain.Base;
using Lim.Domain.Dto;
using Lim.Domain.Entities.Repository;
using Lim.Web.UI.Commits;
using Lim.Web.UI.Handlers;
using Lim.Web.UI.Models.Api;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Lim.Web.UI
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            StaticConfiguration.DisableErrorTraces = false;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
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
    }
}