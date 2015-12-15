using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Toolbox.Mapping;

namespace Lim.Schedule.Service.Installers
{
    public class MappingInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            AutoMapperConfiguration.Configure();
            Mapper.Configuration.ConstructServicesUsing(container.Resolve);
        }
    }
}
