using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Enums;
using Shared.Logging;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install RepositoryInstaller", SystemName.UserManagement);

            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(INamedEntityRepository<>)).ImplementedBy(typeof(NamedEntityRepository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IValueEntityRepository<>)).ImplementedBy(typeof(ValueEntityRepository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IEntityNoteRepository<>)).ImplementedBy(typeof(EntityNoteRepository<>)).LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<ICustomerRepository>().BasedOn(typeof(IRepository<>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<ICustomerRepository>().BasedOn(typeof(INamedEntityRepository<>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<ICustomerRepository>().BasedOn(typeof(IValueEntityRepository<>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<ICustomerRepository>().BasedOn(typeof(IEntityNoteRepository<>)).WithServiceAllInterfaces().LifestyleTransient());

            this.Info(() => "Successfully installed RepositoryInstaller", SystemName.UserManagement);
        }
    }
}