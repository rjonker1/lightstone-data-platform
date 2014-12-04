using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using PackageBuilder.Api.Helpers.Extensions;
using PackageBuilder.Api.Installers;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.States.Commands;
using Shared.BuildingBlocks.Api.ExceptionHandling;
using Shared.BuildingBlocks.Api.Security;

namespace PackageBuilder.Api
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            var handler = container.Resolve<IHandleMessages>();

            // Import Industries, States and DataProviders
            handler.Handle(new CreateIndustry(new Guid(), "All", true));
            foreach (var state in (StateName[]) Enum.GetValues(typeof (StateName)))
                handler.Handle(new CreateState(Guid.NewGuid(), state));
            handler.Handle(new ImportDataProvider());
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            // Perform registation that should have an application lifetime
            base.ConfigureApplicationContainer(container);

            //container.Install(FromAssembly.InThisApplication());
            container.Install(
                new RepositoryInstaller(),
                new NHibernateInstaller(),
                new CommandInstaller(),
                new BusInstaller(),
                new NEventStoreInstaller(),
                new AutoMapperInstaller(),
                new ServiceLocatorInstaller()
                );

            container.Register(Component.For<IAuthenticateUser>().ImplementedBy<UmApiAuthenticator>());
            //container.Register(Component.For<IPackageLookupRepository>().Instance(PackageLookupMother.GetCannedVersion())); // Canned test data (sliver implementation)
        }

        protected override void RequestStartup(IWindsorContainer container, IPipelines pipelines, NancyContext context)
        {
            //Make every request SSL based
            //pipelines.BeforeRequest += ctx =>
            //{
            //    return (!ctx.Request.Url.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase)) ?
            //        (Response)HttpStatusCode.Unauthorized :
            //        null;
            //};
            //pipelines.EnableStatelessAuthentication(container.Resolve<IAuthenticateUser>());

            pipelines.OnError.AddItemToEndOfPipeline((z, a) =>
            {
                //log.Error("Unhandled error on request: " + context.Request.Url + " : " + a.Message, a);
                return ErrorResponse.FromException(a);
            });
            pipelines.EnableCors(); // cross origin resource sharing
            pipelines.AddTransactionScope(container);

            base.RequestStartup(container, pipelines, context);
        }
    }
}