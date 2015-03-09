using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install RepositoryInstaller");

            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(INamedEntityRepository<>)).ImplementedBy(typeof(NamedEntityRepository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IValueEntityRepository<>)).ImplementedBy(typeof(ValueEntityRepository<>)).LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<ICustomerRepository>().BasedOn(typeof(IRepository<>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<ICustomerRepository>().BasedOn(typeof(INamedEntityRepository<>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<ICustomerRepository>().BasedOn(typeof(IValueEntityRepository<>)).WithServiceAllInterfaces().LifestyleTransient());

            this.Info(() => "Successfully installed RepositoryInstaller");
        }
    }
}