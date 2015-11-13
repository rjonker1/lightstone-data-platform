using System;
using System.Configuration;
using System.Net.Mail;
using DataPlatform.Shared.Helpers.Extensions;
using Workflow.Reporting.Helpers;

namespace Workflow.Reporting.NotificationSender
{
    public class EmailNotification : ISendNotifications
    {
        private IEmailBuilder _emailBuilder;

        public EmailNotification(IEmailBuilder emailBuilder)
        {
            _emailBuilder = emailBuilder;
        }

        public void Send(string subject, string body)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    _emailBuilder.MailSubject = subject;
                    _emailBuilder.MailBody = body;

                    var mailMessage = _emailBuilder.BuildMessage();

                    mailMessage.To.Add(ConfigurationManager.AppSettings["report/email/to"].ToLower());
                    mailMessage.To.Add(ConfigurationManager.AppSettings["report/email/to/secondary"].ToLower());

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