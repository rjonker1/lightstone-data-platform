using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Messaging;

namespace Workflow.Bus.Installers
{
    //todo: Move to shared
    public class ConsumerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory)).BasedOn(typeof(IHandleMessages<>)).WithServiceAllInterfaces().LifestyleTransient());
        }
    }
}