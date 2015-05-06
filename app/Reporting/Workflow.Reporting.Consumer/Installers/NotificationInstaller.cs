using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Reporting.NotificationSender;

namespace Workflow.Reporting.Consumer.Installers
{
    public class NotificationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof (ISendNotifications<>)).ImplementedBy(typeof(EmailNotification<>)).LifestyleTransient());
        }
    }
}