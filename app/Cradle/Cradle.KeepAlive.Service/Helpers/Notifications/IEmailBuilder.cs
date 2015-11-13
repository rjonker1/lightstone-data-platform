using System.Net.Mail;

namespace Cradle.KeepAlive.Service.Helpers.Notifications
{
    public interface IEmailBuilder
    {
        string MailSubject { get; set; }
        string MailBody { get; set; }
        Attachment Attachment { get; set; }
        MailMessage MailMessage { get; set; }
        MailMessage BuildMessage();
        void AddAttachment(Attachment attachment);
    }
}