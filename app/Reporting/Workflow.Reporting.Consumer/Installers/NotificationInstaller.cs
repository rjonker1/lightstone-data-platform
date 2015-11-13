using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Reporting.Helpers;
using Workflow.Reporting.NotificationSender;

namespace Workflow.Reporting.Consumer.Installers
{
    public class NotificationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof (ISendNotificationsWithAttachment<>)).ImplementedBy(typeof(EmailNotificationWithAttachment<>)).LifestyleTransient());
            container.Register(Component.For(typeof (ISendNotifications)).ImplementedBy(typeof(EmailNotification)).LifestyleTransient());
            container.Register(Component.For(typeof (IEmailBuilder)).ImplementedBy(typeof(EmailBuilder)).LifestyleTransient());
        }
    }
}