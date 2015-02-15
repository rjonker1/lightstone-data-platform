using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UserManagement.Api.Helpers.AutoMapper.Maps;

namespace UserManagement.Api.Installers
{
    public class AutoMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<ICreateAutoMapperMaps>().BasedOn(typeof(ITypeConverter<,>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<ICreateAutoMapperMaps>().BasedOn<ICreateAutoMapperMaps>().WithServiceAllInterfaces().LifestyleTransient());
            Mapper.Configuration.ConstructServicesUsing(container.Resolve);
            foreach (var map in container.ResolveAll<ICreateAutoMapperMaps>())
                map.CreateMaps();
        }
    }
}