using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Billing.Helpers.AutoMapper.Maps;

namespace Workflow.Billing.Consumer.Installers
{
    public class AutoMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<ICreateAutoMapperMaps>().BasedOn<ICreateAutoMapperMaps>().WithServiceAllInterfaces().LifestyleTransient());
            Mapper.Configuration.ConstructServicesUsing(container.Resolve);
            foreach (var map in container.ResolveAll<ICreateAutoMapperMaps>())
                map.CreateMaps();
        }
    }
}