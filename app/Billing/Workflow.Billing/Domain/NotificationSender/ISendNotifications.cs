using System.Net.Mail;

namespace Workflow.Billing.Domain.NotificationSender
{
    public interface ISendNotifications
    {
        void Send(MailMessage mailMessage);
    }
}