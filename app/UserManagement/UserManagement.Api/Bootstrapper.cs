using System.Linq;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using Nancy.Conventions;
using Nancy.Session;
using Shared.BuildingBlocks.Api.ExceptionHandling;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Api.Helpers.Extensions;
using UserManagement.Api.Installers;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.CommercialStates;
using UserManagement.Domain.Entities.Commands.ContractDurations;
using UserManagement.Domain.Entities.Commands.ContractTypes;
using UserManagement.Domain.Entities.Commands.CreateSources;
using UserManagement.Domain.Entities.Commands.EscalationTypes;
using UserManagement.Domain.Entities.Commands.PaymentTypes;
using UserManagement.Domain.Entities.Commands.PlatformStatuses;
using UserManagement.Domain.Entities.Commands.Provinces;
using UserManagement.Domain.Entities.Commands.Roles;
using UserManagement.Domain.Entities.Commands.UserTypes;
using UserManagement.Infrastructure.Helpers;
using ISession = NHibernate.ISession;

namespace UserManagement.Api
{

    public class Bootstrapper : WindsorNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            var containerHandler = container.Resolve<IHandleMessages>();
            ImportStartupData(containerHandler);
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            // Perform registations that should have an application lifetime
            base.ConfigureApplicationContainer(container);            

            container.Install(
                new NHibernateInstaller(),
                new RepositoryInstaller(),
                new CommandInstaller(),
                new BusInstaller(),
                new ServiceLocatorInstaller(),
                new AutoMapperInstaller(),
                new HelperInstaller(),
                new ApiClientInstaller(),
                new RedisInstaller(),
                new AuthenticationInstaller()
                );

            //Drop create
            //new SchemaExport(container.Resolve<NHibernate.Cfg.Configuration>()).Create(false, true);
        }

        private void ImportStartupData(IHandleMessages handler)
        {
            handler.Handle(new ImportRole());
            handler.Handle(new ImportUserType());
            handler.Handle(new ImportProvince());
            handler.Handle(new ImportContractDuration());
            handler.Handle(new ImportEscalationType());
            handler.Handle(new ImportContractType());
            handler.Handle(new ImportCommercialState());
            handler.Handle(new ImportCreateSource());
            handler.Handle(new ImportPlatformStatus());
            handler.Handle(new ImportPaymentType());
        }

        //Updates schema if there are any structural changes
        protected override void RequestStartup(IWindsorContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.BeforeRequest.AddItemToEndOfPipeline(nancyContext =>
            {
                this.Info(() => "Api invoked at {0}[{1}]".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url));
                return null;
            });
            pipelines.AfterRequest.AddItemToEndOfPipeline(nancyContext => this.Info(() => "Api invoked successfully at {0}[{1}]".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url)));
            pipelines.OnError.AddItemToEndOfPipeline((nancyContext, exception) =>
            {
                this.Error(() => "Error on Api request {0}[{1}] => {2}".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url, exception));
                var fromException = ErrorResponse.FromException(exception);
                fromException.Headers.Add("Access-Control-Allow-Origin", "*");
                fromException.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
                fromException.Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");
                return fromException;
            });
            pipelines.EnableCors(); // cross origin resource sharing
            pipelines.AddTransactionScope(container);

            AddLookupData(pipelines, container.Resolve<IRetrieveEntitiesByType>());

            base.RequestStartup(container, pipelines, context);
        }

        private static void AddLookupData(IPipelines pipelines, IRetrieveEntitiesByType entityRetriever)
        {
            pipelines.AddLookupDataToViewBag<PaymentType>(entityRetriever);
            pipelines.AddLookupDataToViewBag<PlatformStatus>(entityRetriever);
            pipelines.AddLookupDataToViewBag<CreateSource>(entityRetriever);
            pipelines.AddLookupDataToViewBag<CommercialState>(entityRetriever);
            pipelines.AddLookupDataToViewBag<ContractType>(entityRetriever);
            pipelines.AddLookupDataToViewBag<EscalationType>(entityRetriever);
            pipelines.AddLookupDataToViewBag<ContractDuration>(entityRetriever);
            pipelines.AddLookupDataToViewBag<Province>(entityRetriever);
            pipelines.AddLookupDataToViewBag<UserType>(entityRetriever);
            pipelines.AddLookupDataToViewBag<Role>(entityRetriever);
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Content"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/fonts"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/font-awesome"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Scripts"));
        }
    }
}