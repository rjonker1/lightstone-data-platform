using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Billing.Domain.NotificationSender;

namespace Workflow.Billing.Installers
{
    public class NotificationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(ISendNotifications)).ImplementedBy(typeof(EmailNotification)).LifestyleTransient());
        }
    }
}