using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PackageBuilder.Api.Helpers.AutoMapper.Maps;

namespace PackageBuilder.Api.Installers
{
    public class AutoMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Not available in current stable release of AutoMapper
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.BindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            //});
            container.Register(Classes.FromAssemblyContaining<ICreateAutoMapperMaps>().BasedOn(typeof(ITypeConverter<,>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<ICreateAutoMapperMaps>().BasedOn<ICreateAutoMapperMaps>().WithServiceAllInterfaces().LifestyleTransient());
            Mapper.Configuration.ConstructServicesUsing(container.Resolve);
            foreach (var map in container.ResolveAll<ICreateAutoMapperMaps>())
                map.CreateMaps();
        }
    }
}