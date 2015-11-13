using System.Net.Mail;
using System.Text;
using Toolbox.Emailing.Domain;
using Toolbox.Emailing.Infrastructure;

namespace Toolbox.Emailing.Smtp
{
    public class HtmlMailMessageBuilder : AbstractMessageBuilder<EmailMessage, MailMessage>
    {
        public override MailMessage Build(EmailMessage command)
        {
            return new MailMessage(command.FromAddress, command.Address, command.Subject, command.Body)
            {
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8
            };
        }
    }
}
