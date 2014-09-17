using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using PackageBuilder.Data.NHibernate;
using PackageBuilder.Domain.Helpers.Cqrs.NEventStore;
using PackageBuilder.Domain.Helpers.Windsor.Installers;
using PackageBuilder.TestHelper.Mothers;
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

            //pipelines.EnableStatelessAuthentication(container.Resolve<IAuthenticateUser>());
            pipelines.EnableCors(); // cross origin resource sharing

            //NHibernateBootstrapper.Build();
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
            // Perform registation that should have an application lifetime
            base.ConfigureApplicationContainer(container);

            

            container.Register(Component.For<IAuthenticateUser>().ImplementedBy<UmApiAuthenticator>());
            container.Register(Component.For<IConstructAggregates>().ImplementedBy<AggregateFactory>());
            container.Register(Component.For<IDetectConflicts>().ImplementedBy<ConflictDetector>());
            container.Register(Component.For<IRepository>().ImplementedBy<EventStoreRepository>());
            //container.Register(Component.For<IPackageLookupRepository>().Instance(PackageLookupMother.GetCannedVersion())); // Canned test data (sliver implementation)
            container.Install(FromAssembly.Containing<CommandInstaller>());
        }
    }
}