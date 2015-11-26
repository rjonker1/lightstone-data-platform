using System.Configuration;
using Workflow.Billing.Domain.NotificationSender;

namespace Workflow.Billing.Helpers.Schedules
{
    // Wrapper class required due to MailMessage not serializing due to MS internal socket dependecies
    public class EmailSchedule
    {
        public void SendStageBillingNotification()
        {
            var message = new SimpleMailMessage
            {
                Body = "Please note that StageBilling has run, please review transactions and Customer/Client information by the 28th of this month.",
                Subject = "StageBilling Process Complete"
            };

            var mailMessage = message.ToMailMessage();
            mailMessage.To.Add(ConfigurationManager.AppSettings["report/email/to"].ToLower());

            new EmailNotification().Send(mailMessage);
        }
    }
}