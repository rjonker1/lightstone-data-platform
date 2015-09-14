using System.Configuration;
using System.Net.Mail;
using System.Text;
using Cradle.KeepAlive.Service.Helpers.Notifications;

namespace Cradle.KeepAlive.Service.NotificationSender
{
    public class EmailBuilder : IEmailBuilder
    {
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public Attachment Attachment { get; set; }
        public MailMessage MailMessage { get; set; }

        public MailMessage BuildMessage()
        {
            MailMessage = new MailMessage
            {
                From = new MailAddress(ConfigurationManager.AppSettings["report/email/from"].ToLower()),
                Subject = MailSubject,
                IsBodyHtml = true,
                Body = MailBody,
                BodyEncoding = Encoding.UTF8
            };

            if (Attachment != null) MailMessage.Attachments.Add(Attachment);

            return MailMessage;
        }

        public void AddAttachment(Attachment attachment)
        {
            Attachment = attachment;
        }
    }
}