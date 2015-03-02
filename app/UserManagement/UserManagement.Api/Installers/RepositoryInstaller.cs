using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UserManagement.Domain.Core.Repositories;

namespace UserManagement.Api.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(INamedEntityRepository<>)).ImplementedBy(typeof(NamedEntityRepository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IValueEntityRepository<>)).ImplementedBy(typeof(ValueEntityRepository<>)).LifestyleTransient());
        }
    }
}