using System;
using System.Net.Mail;
using DataPlatform.Shared.Helpers.Extensions;

namespace Workflow.Billing.Domain.NotificationSender
{
    public class EmailNotification : ISendNotifications
    {
        public void Send(MailMessage mailMessage)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    this.Info(() => "Sending Email notification to: " + mailMessage.To);
                    client.Send(mailMessage);
                    this.Info(() => "Sent Email notification to: " + mailMessage.To);
                }
            }
            catch (Exception e)
            {
                this.Error(() => "Erorr sending email " + e);
            }
        }
    }
}