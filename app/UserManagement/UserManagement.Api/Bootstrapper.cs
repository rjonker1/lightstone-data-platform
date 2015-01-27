using Castle.Windsor;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using UserManagement.Api.Helpers.Extensions;
using UserManagement.Api.Installers;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities.Commands.ContractDurations;
using UserManagement.Domain.Entities.Commands.ContractTypes;
using UserManagement.Domain.Entities.Commands.EscalationTypes;
using UserManagement.Domain.Entities.Commands.Provinces;
using UserManagement.Domain.Entities.Commands.Roles;
using UserManagement.Domain.Entities.Commands.UserTypes;

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
            // Perform registation that should have an application lifetime
            base.ConfigureApplicationContainer(container);

            //container.Install(FromAssembly.InThisApplication());
            container.Install(
                new NHibernateInstaller(),
                new RepositoryInstaller(),
                new CommandInstaller(),
                new BusInstaller()
                );

            //Drop create
            //new SchemaExport(container.Resolve<NHibernate.Cfg.Configuration>()).Create(false, true);
        }

        //TODO: Update to include check in UserType Repository for existing records - to prevent duplications
        private void ImportStartupData(IHandleMessages handler)
        {
            handler.Handle(new ImportRole());
            handler.Handle(new ImportUserType());
            handler.Handle(new ImportProvince());
            handler.Handle(new ImportContractDuration());
            handler.Handle(new ImportEscalationType());
            handler.Handle(new ImportContractType());
        }

        //Updates schema if there are any structural changes
        protected override void RequestStartup(IWindsorContainer container, IPipelines pipelines, NancyContext context)
        {
            //pipelines.EnableCors(); // cross origin resource sharing

            pipelines.AddTransactionScope(container);

            base.RequestStartup(container, pipelines, context);
        }
        
    }
}