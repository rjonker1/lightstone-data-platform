using System.Linq;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.EventHandlers.Packages;
using PackageBuilder.Domain.MessageHandling;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.Installers
{
    public class when_installing_command_handlers : Specification
    {
        class WindsorInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(Component.For<IWindsorContainer>().Instance(container));
            }
        }

        readonly IWindsorContainer _container = new WindsorContainer();

        /// <summary>
        /// Override the LifestyleType of LifestylePerWebRequest to avoid exception below:
        /// 
        /// Castle.MicroKernel.ComponentResolutionException
        /// Looks like you forgot to register the http module Castle.MicroKernel.Lifestyle.PerWebRequestLifestyleModule
        /// To fix this add
        /// <add name="PerRequestLifestyle" type="Castle.MicroKernel.Lifestyle.PerWebRequestLifestyleModule, Castle.Windsor" />
        /// to the <httpModules> section on your web.config.
        /// If you plan running on IIS in Integrated Pipeline mode, you also need to add the module to the <modules> section under <system.webServer>.
        /// Alternatively make sure you have Microsoft.Web.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35 assembly in your GAC (it is installed by ASP.NET MVC3 or WebMatrix) and Windsor will be able to register the module automatically without having to add anything to the config file.
        /// </summary>
        /// <param name="model"></param>
        void Kernel_ComponentModelCreated(ComponentModel model)
        {
            if (model.LifestyleType == LifestyleType.Undefined)
                model.LifestyleType = LifestyleType.Transient;

            if (model.LifestyleType == LifestyleType.PerWebRequest)
                model.LifestyleType = LifestyleType.Transient;
        }

        public override void Observe()
        {
            _container.Kernel.ComponentModelCreated += Kernel_ComponentModelCreated;
            _container.Install(new WindsorInstaller(), new BusInstaller(),new CommandInstaller(), new RavenDbInstaller(), new NEventStoreInstaller());
        }

        [Observation]
        public void should_resolve_IHandleMessages()
        {
            _container.Resolve<IHandleMessages>().ShouldBeType<MessagesHandlerResolver>();
        }

        [Observation]
        public void should_resolve_all_handlers()
        {
            var registeredHandlers = Core.Helpers.Extensions.TypeExtensions.FindDerivedTypesFromAssembly(Assembly.GetAssembly(typeof(PackageCreatedHandler)), typeof(IHandleMessages<>), true, false).OrderBy(x => x.Name);
            var resolvedHandlers = _container.ResolveAll<IHandleMessages>().Select(x => x.GetType()).Where(x => x != typeof(MessagesHandlerResolver)).OrderBy(x => x.Name);
                
             registeredHandlers.ShouldEqual(resolvedHandlers);
        }
    }
}