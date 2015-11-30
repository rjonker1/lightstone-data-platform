using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;

namespace PackageBuilder.Api.Installers
{
    public class LaceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IEntryPoint>().ImplementedBy<EntryPointService>().LifestyleTransient());
            //container.Register(Component.For<IEntryPointAsync>().ImplementedBy<EntryPointAsyncService>().LifestyleTransient());
        }
    }
}