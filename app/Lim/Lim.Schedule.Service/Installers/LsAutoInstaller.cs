using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lim.Core;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Repository;
using Toolbox.LSAuto.Entities;
using Toolbox.LSAuto.Entities.Factory;

namespace Lim.Schedule.Service.Installers
{
    public class LsAutoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<LsAutoConfiguration>().UsingFactoryMethod(c => LsAutoFactoryManager.BuildConfiguration()).LifestyleTransient());

           
            container.Register(Component.For<IPersist<DataSetDto>, DataSetCommit>());
            container.Register(Component.For<IPersist<ViewDto>, ViewCommit>());
        }
    }
}
