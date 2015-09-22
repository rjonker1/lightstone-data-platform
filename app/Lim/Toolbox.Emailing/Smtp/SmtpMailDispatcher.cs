using System.Net.Mail;
using Toolbox.Emailing.Domain;

namespace Toolbox.Emailing.Smtp
{
    public class SmtpMailDispatcher : AbstractMailDispatcher<MailMessage>
    {
        public override void Send(MailMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Send(message);
            }
        }
    }
}
