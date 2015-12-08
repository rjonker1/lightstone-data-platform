using Api.Helpers.AutoMapper;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Enums;
using Shared.Logging;

namespace Api.Installers
{
    public class AutoMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install AutoMapperInstaller");

            container.Register(Classes.FromAssemblyContaining<ICreateAutoMapperMaps>().BasedOn(typeof(ITypeConverter<,>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<ICreateAutoMapperMaps>().BasedOn<ICreateAutoMapperMaps>().WithServiceAllInterfaces().LifestyleTransient());
            Mapper.Configuration.ConstructServicesUsing(container.Resolve);
            foreach (var map in container.ResolveAll<ICreateAutoMapperMaps>())
                map.CreateMaps();

            this.Info(() => "Successfully installed AutoMapperInstaller");
        }
    }
}